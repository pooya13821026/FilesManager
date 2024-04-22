using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.Application.Models.SiteSetting;
public class PaymentSettings
{
    public string? Applicant { get; set; }
    public int TerminalId { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? CallbackUrlPath { get; set; }
}
