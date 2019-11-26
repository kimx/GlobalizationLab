using GlobalizationLab.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalizationLab.Core
{
    public class LocalizedModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            var items = attributes.ToList();
            if (AddImplicitRequiredAttributeForValueTypes && metadata.IsRequired &&
                !items.Any(a => a is RequiredAttribute))
                items.Add(new RequiredAttribute());

            foreach (var attr in items.OfType<ValidationAttribute>())
            {
                attr.ErrorMessageResourceType = typeof(Resources);
                attr.ErrorMessageResourceName="PropertyValueRequired";
                continue;
            }
            return base.GetValidators(metadata, context, attributes);
        }
    }
}