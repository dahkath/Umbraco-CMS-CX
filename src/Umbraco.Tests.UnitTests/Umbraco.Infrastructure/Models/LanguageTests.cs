﻿using Newtonsoft.Json;
using NUnit.Framework;
using Umbraco.Core.Models;
using Umbraco.Tests.Common.Builders;

namespace Umbraco.Tests.UnitTests.Umbraco.Infrastructure.Models
{
    [TestFixture]
    public class LanguageTests
    {
        private readonly LanguageBuilder _builder = new LanguageBuilder();

        [Test]
        public void Can_Deep_Clone()
        {
            var item = _builder.Build();

            var clone = (Language) item.DeepClone();
            Assert.AreNotSame(clone, item);
            Assert.AreEqual(clone, item);
            Assert.AreEqual(clone.CreateDate, item.CreateDate);
            Assert.AreEqual(clone.CultureName, item.CultureName);
            Assert.AreEqual(clone.Id, item.Id);
            Assert.AreEqual(clone.IsoCode, item.IsoCode);
            Assert.AreEqual(clone.Key, item.Key);
            Assert.AreEqual(clone.UpdateDate, item.UpdateDate);

            //This double verifies by reflection
            var allProps = clone.GetType().GetProperties();
            foreach (var propertyInfo in allProps)
            {
                Assert.AreEqual(propertyInfo.GetValue(clone, null), propertyInfo.GetValue(item, null));
            }
        }

        [Test]
        public void Can_Serialize_Without_Error()
        {
            var item = _builder.Build();

            Assert.DoesNotThrow(() => JsonConvert.SerializeObject(item));
        }
    }
}
