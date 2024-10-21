using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Utility
{
    public class EmailSender : IEmailSender //Ky rresht deklaron një klasë EmailSender që
                                            //implementon ndërfaqen IEmailSender.
                                            //Kjo ndërfaqe përcakton kontratën për dërgimin e email-eve.
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //logic to send emiail
            return Task.CompletedTask; 
        }
    }
}
//Kjo metodë asinkrone SendEmailAsync është pjesë e
//kontratës së IEmailSender dhe është përgjegjëse për
//dërgimin e email-eve. Ajo pranon tre parametra:

//string email: adresa email e marrësit.
//string subject: subjekti i email-it.
//string htmlMessage: përmbajtja e email-it në format HTML.