using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalRadiation.Models.MetadataProvider
{
    public class MyMetadataProvider : IDisplayMetadataProvider, IValidationMetadataProvider
    {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
        }

        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
        }
    }
}
