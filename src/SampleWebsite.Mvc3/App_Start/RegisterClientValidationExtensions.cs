using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(SampleWebsite.Mvc3.App_Start.RegisterClientValidationExtensions), "Start")]
 
namespace SampleWebsite.Mvc3.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}