using System;
using SharpCms.Core.DataObjects;

namespace SharpCms.Core.Data
{
    public class TemporaryData
    {
        public static PageInfo GetSiteTree()
        {
            var siteTree =

                new PageInfo
                    {
                        Id = Guid.NewGuid(),
                        Menuname = string.Empty,
                        InPath = true,
                        PageName = "root",
                        Children = new[]
                            {
                                new PageInfo
                                    {
                                        Id = Guid.NewGuid(),
                                        PageName = "Home",
                                        Menuname = "Home",
                                        Description =
                                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. ",
                                        Template = "TemplateA",
                                        InPath = false,
                                        Children = new[]
                                            {
                                                new PageInfo
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        PageName = "Company",
                                                        Menuname = "Company",
                                                        Description =
                                                            "Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. ",
                                                        Template = "TemplateB",
                                                        InPath = false
                                                    },
                                                new PageInfo
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        PageName = "Haelt",
                                                        Menuname = "Haelt",
                                                        Description =
                                                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. ",
                                                        Template = "TemplateB",
                                                        InPath = false
                                                    }
                                            }
                                    },
                                new PageInfo
                                    {
                                        Id = Guid.NewGuid(),
                                        PageName = "Products",
                                        Menuname = "Products",
                                        Description =
                                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. ",
                                        Template = "TemplateA",
                                        InPath = false,
                                        Children = new[]
                                            {
                                                new PageInfo
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        PageName = "Product A",
                                                        Menuname = "Product A",
                                                        Description =
                                                            "In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. ",
                                                        Template = "TemplateB",
                                                        InPath = false
                                                    },
                                                new PageInfo
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        PageName = "Product B",
                                                        Menuname = "Product B",
                                                        Description = "Nullam dictum felis eu pede mollis pretium. ",
                                                        Template = "TemplateB",
                                                        InPath = false
                                                    },
                                                new PageInfo
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        PageName = "Product C",
                                                        Menuname = "Product C",
                                                        Description =
                                                            "Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus.  ",
                                                        Template = "TemplateB",
                                                        InPath = false
                                                    },
                                                new PageInfo
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        PageName = "Product D",
                                                        Menuname = "Product D",
                                                        Description =
                                                            "Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim.  ",
                                                        Template = "TemplateB",
                                                        InPath = false
                                                    },
                                                new PageInfo
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        PageName = "Product E",
                                                        Menuname = "Product E",
                                                        Description =
                                                            "Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum.",
                                                        Template = "TemplateB",
                                                        InPath = false
                                                    }
                                            }
                                    },
                                new PageInfo
                                    {
                                        Id = Guid.NewGuid(),
                                        PageName = "About Us",
                                        Menuname = "About Us",
                                        Description =
                                            "Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. ",
                                        Template = "TemplateA",
                                        InPath = false,
                                        Children = new[]
                                            {
                                                new PageInfo
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        PageName = "Contact",
                                                        Menuname = "Contact",
                                                        Description =
                                                            "Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum.",
                                                        Template = "TemplateA",
                                                        InPath = false
                                                    },
                                                new PageInfo
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        PageName = "Jobs",
                                                        Menuname = "Jobs",
                                                        Description =
                                                            "Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem.",
                                                        Template = "TemplateA",
                                                        InPath = false
                                                    }
                                            }
                                    },
                                new PageInfo
                                    {
                                        Id = Guid.NewGuid(),
                                        PageName = "Imprint",
                                        Menuname = "Imprint",
                                        Description =
                                            " Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt.",
                                        Template = "TemplateA",
                                        InPath = false,
                                        Children = new[]
                                            {
                                                new PageInfo
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        PageName = "The Way to Us",
                                                        Menuname = "The Way to Us",
                                                        Description =
                                                            " Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc.",
                                                        Template = "TemplateB",
                                                        InPath = false
                                                    }
                                            }
                                    }
                            }
                    };

            return siteTree;
        }
    }
}
