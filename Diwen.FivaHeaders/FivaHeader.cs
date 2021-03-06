//
//  This file is part of Diwen.FivaHeaders.
//
//  Author:
//       John Nordberg <john.nordberg@gmail.com>
//
//  Copyright (c) 2017-2020 John Nordberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace Diwen.FivaHeaders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Serialization;

    public class FivaHeader
    {
	 	static AssemblyName assembly = Assembly.GetExecutingAssembly().GetName();
		static string VersionComment = $" {assembly.Name} {assembly.Version} ";

        public DateTime InstanceCreationDateTime { get; set; }

		[XmlElement(DataType = "date")]
        public DateTime ReportingPeriod { get; set; }

        // For some reason there are two nearly identical schemas
        // The only actual difference is that one schema
        // has one more allowed value (MFI) for ReportingEntityType
        public ReportingEntityType ReportingEntityType { get; set; }

        public string ReportingEntity { get; set; }
        public string TypeOfReportingInstitution { get; set; }
        public string ReportingApplicationName { get; set; }
        public string ReportingApplicationVersion { get; set; }
        public string ContactPersonFirstName { get; set; }
        public string ContactPersonLastName { get; set; }
        public string ContactPersonEmail { get; set; }
        public string ContactPersonTelephone { get; set; }
        public string Comment { get; set; }
		[XmlElement(DataType = "boolean")]
        public bool TestFlag { get; set; }

		// Number of files referenced could be read from BasicHeader File array, 
		// but for some reason it needs to be specified here, and only if it is 0 ?
		public int? NumberOfFiles { get; set; }

		// ModuleCode is already given in header file name, but for some reason 
		// it needs to specified here, and only if NumberOfFiles is 0 ?
		public string ModuleCode { get; set; }

		public BasicHeader BasicHeader { get; set; } = new BasicHeader();

        ////[XmlIgnore]
        ////public bool Test
        ////{
		////    // For some reason, instead of using xsd:boolean, 
		////    // the schema goes out of its way to allow other values as well ?
		////    // We have to accomodate for that here :(
        ////    get => XmlConvert.ToBoolean(TestFlag.ToLower());
        ////    set => TestFlag = XmlConvert.ToString(value);
        ////}
	
		[XmlIgnore]
		public bool NumberOfFilesSpecified => NumberOfFiles.HasValue;

        [XmlIgnore]
        public string[] Files
        {
            get => BasicHeader.File.Select(f => f.FilePath).ToArray();
            set => BasicHeader.File = value.Select(f => new ReportFile { FilePath = f }).ToArray();
        }

        [XmlIgnore]
        public string ReportReferenceId
        {
            get => BasicHeader.ReportDataContext.ReportReferenceId;
            set => BasicHeader.ReportDataContext.ReportReferenceId = value;
        }

        static XmlWriterSettings XmlWriterSettings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "\t",
            NamespaceHandling = NamespaceHandling.OmitDuplicates,
            Encoding = Encoding.UTF8
        };

        public bool ContentMatch(FivaHeader other)
        => other != null
            && other.TestFlag == this.TestFlag
		    && other.NumberOfFiles == this.NumberOfFiles
            && other.ReportingEntityType == this.ReportingEntityType
            && other.ReportReferenceId.Equals(this.ReportReferenceId)
            && other.TypeOfReportingInstitution.Equals(this.TypeOfReportingInstitution)
            && other.ReportingEntity.Equals(this.ReportingEntity)
            && other.ReportingPeriod.Equals(this.ReportingPeriod)
		    && other.ModuleCode == null
		    	? this.ModuleCode == null
				: other.ModuleCode.Equals(this.ModuleCode)
            && other.Comment == null
                ? this.Comment == null
                : other.Comment.Equals(this.Comment)
            && other.Files.SequenceEqual(this.Files);

        private static Dictionary<string, string> xmlNames = new Dictionary<string, string>()
        {
            ["bh"] = "http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader",
            ["xsi"] = "http://www.w3.org/2001/XMLSchema-instance"
        };

        private static Lazy<XmlSerializerNamespaces> namespaces 
		= new Lazy<XmlSerializerNamespaces>(() => GetNamespaces());

        private static Dictionary<Type, XmlSerializer> serializers 
		= new Dictionary<Type, XmlSerializer>();

        private static XmlSerializerNamespaces Namespaces => namespaces.Value;

        private static XmlSerializerNamespaces GetNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            xmlNames.ToList().ForEach(n => ns.Add(n.Key, n.Value));
            return ns;
        }

        internal static T FromFile<T>(string path) where T : FivaHeader
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                return FromStream<T>(stream);
        }

        private static T FromStream<T>(Stream stream) where T : FivaHeader
            => (T)GetSerializer<T>().Deserialize(stream);

        internal static void ToFile<T>(T header, string path) where T : FivaHeader
        {
            using (var writer = XmlWriter.Create(path, XmlWriterSettings))
		    {
                ToXmlWriter(writer, header);
				writer.WriteComment(VersionComment);
		    }
        }

        private static void ToXmlWriter<T>(XmlWriter writer, T header) where T : FivaHeader
            => GetSerializer<T>().Serialize(writer, header, Namespaces);

        private static XmlSerializer GetSerializer<T>() where T : FivaHeader
            => GetSerializer(typeof(T));

        public static XmlDocument ToXmlDocument<T>(T header) where T : FivaHeader
        {
            var document = new XmlDocument();
            var navigator = document.CreateNavigator();
            using (XmlWriter writer = navigator.AppendChild())
		    {
                GetSerializer<T>().Serialize(writer, header);
			writer.WriteComment(VersionComment);
		    }

            return document;
        }

        private static XmlSerializer GetSerializer(Type type)
        {
            if (!serializers.ContainsKey(type))
                serializers.Add(type, new XmlSerializer(type));
            return serializers[type];
        }
    }
}
