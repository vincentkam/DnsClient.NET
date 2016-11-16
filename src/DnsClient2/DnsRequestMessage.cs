﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnsClient2
{
    public class DnsRequestMessage
    {
        private static ushort _uniqueId = 0;

        public static ushort GetNextUniqueId()
        {
            if (_uniqueId == ushort.MaxValue || _uniqueId == 0)
            {
                _uniqueId = (ushort)(new Random()).Next(ushort.MaxValue / 2);
            }

            return _uniqueId++;
        }

        public DnsRequestMessage(DnsRequestHeader header, params DnsQuestion[] questions)
        {
            if (header == null)
            {
                throw new ArgumentNullException(nameof(header));
            }
            if (questions == null || questions.Length == 0)
            {
                throw new ArgumentException("At least one question must be specified for the request.", nameof(questions));
            }
            if (header.QuestionCount != questions.Length)
            {
                throw new InvalidOperationException("Header question count and number of questions do not match.");
            }

            Header = header;
            Questions = questions;
        }

        public DnsQuestion[] Questions { get; }

        public DnsRequestHeader Header { get; }
    }
}