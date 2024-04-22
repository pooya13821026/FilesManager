using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.Application.Models.SiteSetting;
public class SmtpSettings
{
    public string Server { get; set; } = string.Empty;
    public int Port { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string LocalDomain { get; set; } = string.Empty;
    public bool UsePickupFolder { get; set; }
    public string PickupFolder { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
    public string FromAddress { get; set; } = string.Empty;
    public string BodyFormat { get; set; } = string.Empty;
}
