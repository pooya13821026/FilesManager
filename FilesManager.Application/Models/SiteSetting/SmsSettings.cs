using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.Application.Models.SiteSetting;
public class SmsSettings
{
    public string SendUrl { get; set; } = string.Empty;
    public string GetCreditUrl { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public object Source { get; set; } = string.Empty;
}
