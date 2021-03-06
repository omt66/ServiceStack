﻿// Copyright (c) Service Stack LLC. All Rights Reserved.
// License: https://raw.github.com/ServiceStack/ServiceStack/master/license.txt


using NUnit.Framework;

namespace ServiceStack.WebHost.IntegrationTests.Tests
{
    [TestFixture]
    public class VirtualPathTests
    {
        public static string ServiceStackBaseUri = Config.ServiceStackBaseUri;

        [Test]
        public void Can_download_static_file_at_root_directory()
        {
            var contents = "{0}/static-root.txt".Fmt(ServiceStackBaseUri).GetStringFromUrl();
            Assert.That(contents, Is.EqualTo("static"));
        }

        [Test]
        public void Can_download_static_file_at_sub_directory()
        {
            var contents = "{0}/Content/static-sub.txt".Fmt(ServiceStackBaseUri).GetStringFromUrl();
            Assert.That(contents, Is.EqualTo("static"));
        }

        [Test]
        public void Can_download_embedded_static_file_at_root_directory()
        {
            var contents = "{0}/static-root-embedded.txt".Fmt(ServiceStackBaseUri).GetStringFromUrl();
            Assert.That(contents, Is.EqualTo("static"));
        }

        [Test]
        public void Can_download_embedded_static_file_at_sub_directory()
        {
            var contents = "{0}/Content/static-sub-embedded.txt".Fmt(ServiceStackBaseUri).GetStringFromUrl();
            Assert.That(contents, Is.EqualTo("static"));
        }

        [Test]
        public void Can_download_default_static_file_at_sub_directory()
        {
            var contents = "{0}/Content".Fmt(ServiceStackBaseUri).GetStringFromUrl();
            Assert.That(contents, Is.EqualTo("static"));
        }

        [Test]
        public void Can_download_default_document_at_root_directory()
        {
            var contents = "{0}/".Fmt(ServiceStackBaseUri).GetStringFromUrl();
            Assert.That(contents, Is.Not.Null);
        }

        [Test]
        public void Can_download_ServiceStack_Template_IndexOperations()
        {
            var contents = "{0}/metadata".Fmt(ServiceStackBaseUri).GetStringFromUrl();
            Assert.That(contents, Is.StringContaining("The following operations are supported."));
        }

        [Test]
        public void Can_download_File_Template_OperationControl()
        {
            var contents = "{0}/json/metadata?op=Hello".Fmt(ServiceStackBaseUri).GetStringFromUrl();
            Assert.That(contents, Is.StringContaining("(File Resource)"));
        }

        [Test]
        public void Can_download_EmbeddedResource_Template_HtmlFormat()
        {
            var contents = "{0}/hello".Fmt(ServiceStackBaseUri).GetStringFromUrl();
            Assert.That(contents, Is.StringContaining("(Embedded Resource)"));
        }
    }
}