﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentDisplayProperties
{
    public abstract class DisplayPropertyConfiguration<TModel> where TModel : class
    {
        public PropertyInstance<TProp> ForProperty<TProp>(Expression<Func<TModel, TProp>> expression) where TProp : class
        {
            PropertyInfo property = (PropertyInfo) (((MemberExpression) expression.Body).Member);
            var displayProperty = new DisplayProperty(property);

            RegisterPropertyWithContainer(displayProperty);

            return new PropertyInstance<TProp>(displayProperty);
        }

        private static void RegisterPropertyWithContainer(IDisplayProperty displayProperty)
        {
            DisplayPropertyContainer.RegisterProperty(displayProperty);
        }
    }
}
