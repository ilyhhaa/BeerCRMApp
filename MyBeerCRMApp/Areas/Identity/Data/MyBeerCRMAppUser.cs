using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyBeerCRMApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MyBeerCRMAppUser class
public class MyBeerCRMAppUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string UserFirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string UseLastName { get; set; }
}


