using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.Application.Models.SiteSetting;
public class JwtSettings
{
    public required string ValidIssuer { get; set; }
    public required List<string> ValidAudiences { get; set; }
    public required string SecurityKey { get; set; }
    public required int TokenValidityInMinutes { get; set; }
    public required int RefreshTokenValidityInDays { get; set; }
}