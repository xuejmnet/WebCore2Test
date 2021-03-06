﻿using Microsoft.AspNetCore.DataProtection.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IdentityServer.CookieAuth
{
    public class XmlRepository : IXmlRepository
    {
        private readonly string _KeyContentPath = "";

        public XmlRepository()
        {
            _KeyContentPath = Path.Combine(Directory.GetCurrentDirectory(), "ShareKeys", "key.xml");
        }

        public IReadOnlyCollection<XElement> GetAllElements()
        {
            var elements = new List<XElement>() { XElement.Load(_KeyContentPath) };
            return elements;
        }

        public void StoreElement(XElement element, string friendlyName)
        {

        }
    }
}
