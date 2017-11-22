//
//  This file is part of Diwen.FivaHeaders.
//
//  Author:
//       John Nordberg <john.nordberg@gmail.com>
//
//  Copyright (c) 2017 John Nordberg
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
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(Namespace = "http://www.fiva.fi/eu/fr/esrs/Header/FivaAIFMDHeader")]
    [XmlRoot("FivaAIFMDHeader", Namespace = "http://www.fiva.fi/eu/fr/esrs/Header/FivaAIFMDHeader", IsNullable = false)]
    public partial class FivaAIFMDHeader : FivaHeader
    {
        public new ReportingEntityType ReportingEntityType
        {
            get => base.ReportingEntityType;
            set => base.ReportingEntityType =
                (value != ReportingEntityType.MFI)
                ? value
                : throw new ArgumentException( $"ReportingEntityType {value:G} not allowed for AIFMD", nameof(value));
        }

        public static FivaAIFMDHeader FromFile(string path)
        => FromFile<FivaAIFMDHeader>(path);

        public void ToFile(string path)
        => ToFile<FivaAIFMDHeader>(this, path);
    }
}
