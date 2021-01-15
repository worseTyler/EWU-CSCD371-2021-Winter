using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom
{
    public record FingerPrint(
        string CreatedBy, DateTime? CreatedDateTime)
    {
        public FingerPrint(
            string createdBy) : this(createdBy, DateTime.Now)
        {
        }

        public FingerPrint(
            string createdBy, DateTime createdDateTime, string? modifiedBy) : this(createdBy, createdDateTime)
        {
            ModifiedBy = modifiedBy;
        }

        string? _ModifiedBy;
        public string? ModifiedBy
        { 
            get 
            { 
                return _ModifiedBy!; 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Can't be null or whitepace", nameof(value));
                }
                _ModifiedBy = value;
            }
        }
    }
}
