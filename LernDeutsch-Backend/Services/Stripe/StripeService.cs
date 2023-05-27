using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Models.Stripe;
using LernDeutsch_Backend.Services.Identity.SubUsers;
using Stripe;

namespace LernDeutsch_Backend.Services.Stripe
{
    public class StripeService : IStripeService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;
        private readonly ICourseStudentService _courseStudentService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public StripeService(
            ChargeService chargeService,
            CustomerService customerService,
            TokenService tokenService, ICourseStudentService courseStudentService,
            ICourseService courseService,
            IStudentService studentService)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
            _courseStudentService = courseStudentService;
            _studentService = studentService;
            _courseService = courseService;
        }

        public async Task<StripeCustomer> AddStripeCustomerAsync(string Email, string Name, AddStripeCard card, CancellationToken ct)
        {
            TokenCreateOptions tokenOptions = new()
            {
                Card = new TokenCardOptions
                {
                    Name = Name,
                    Number = card.CardNumber.ToString(),
                    ExpYear = card.ExpirationYear.ToString(),
                    ExpMonth = card.ExpirationMonth.ToString(),
                    Cvc = card.Cvc
                }
            };

            Token stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);

            CustomerCreateOptions customerOptions = new()
            {
                Name = Name,
                Email = Email,
                Source = stripeToken.Id
            };

            Customer createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);

            return new StripeCustomer(createdCustomer.Name, createdCustomer.Email, createdCustomer.Id);
        }


        public async Task<bool> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct)
        {
            var student = _studentService.GetUserByUserName(payment.Username);
            var course = _courseService.GetById(new Guid(payment.CourseId));

            if (student == null || course == null)
                return false;

            var getStripeCustomer = await AddStripeCustomerAsync(student.BaseUser.Email,string.Format("{0} {1}",student.BaseUser.FirstName,student.BaseUser.LastName), payment.CreditCard, ct);

            ChargeCreateOptions paymentOptions = new()
            {
                Customer = getStripeCustomer.CustomerId,
                ReceiptEmail = getStripeCustomer.Email,
                Description = "Buying course",
                Currency = "USD",
                Amount = Convert.ToInt32(course.Price * 100) // Convert dollars to cents
            };

            var CreatedPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);
            
            bool statusOfPayment = CreatedPayment == null ? false : true;
            return StatusOfPaymentAndEnrollment(statusOfPayment, course, student);
        }

        private bool StatusOfPaymentAndEnrollment(bool statusOfPayment, Course course, Student student)
        {
            if (!statusOfPayment)
                return false;
            var IsEnrollmentSuccessfull = _courseStudentService.EnrollStudent(course, student) != null ? true : false;
            return IsEnrollmentSuccessfull;
        }
    }
}
