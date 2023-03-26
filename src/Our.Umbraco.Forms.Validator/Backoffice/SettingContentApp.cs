// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Forms.Web.Models.Backoffice;

namespace Our.Umbraco.Forms.Validator.Backoffice;

public class SettingContentApp : IContentAppFactory
{
    public ContentApp? GetContentAppFor(object source, IEnumerable<IReadOnlyUserGroup> userGroups)
    {
        if (source is FormDesign)
        {
            return new ContentApp
            {
                Alias = "formsValidatorSettingContentApp",
                Name = "Validation",
                Icon = "icon-checkbox",
                View = "~/App_Plugins/FormsValidator/views/settingscontentapp.html",
                Weight = 0,
            };
        }

        return null;
    }
}