using System;

namespace RTSafe.DxfCore
{
    public class DxfException : Exception
    {
        private readonly string file;

        public DxfException(string file)
        {
            this.file = file;
        }

        public DxfException(string file, string message)
            : base(message)
        {
            this.file = file;
        }

        public DxfException(string file, string message, Exception innerException)
            : base(message, innerException)
        {
            this.file = file;
        }

        public string File
        {
            get { return this.file; }
        }
    }

    #region section exceptions

    public class DxfHeaderVariableException : DxfException
        {
        private readonly string name;

        public DxfHeaderVariableException(string name, string file)
            : base(file)
        {
            this.name = name;
        }

        public DxfHeaderVariableException(string name, string file, string message)
            : base(file, message)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }
    }

    public class DxfSectionException : DxfException
    {
        private readonly string section;

        public DxfSectionException(string section, string file)
            : base(file)
        {
            this.section = section;
        }

        public DxfSectionException(string section, string file, string message)
            : base(file, message)
        {
            this.section = section;
        }

        public string Section
        {
            get { return this.section; }
        }
    }

    public class InvalidDxfSectionException : DxfSectionException
    {
        public InvalidDxfSectionException(string section, string file)
            : base(section, file)
        {
        }

        public InvalidDxfSectionException(string section, string file, string message)
            : base(section, file, message)
        {
        }
    }

    public class OpenDxfSectionException : DxfSectionException
    {
        public OpenDxfSectionException(string section, string file)
            : base(section, file)
        {
        }

        public OpenDxfSectionException(string section, string file, string message)
            : base(section, file, message)
        {
        }
    }

    public class ClosedDxfSectionException : DxfSectionException
    {
        public ClosedDxfSectionException(string section, string file)
            : base(section, file)
        {
        }

        public ClosedDxfSectionException(string section, string file, string message)
            : base(section, file, message)
        {
        }
    }

    #endregion

    #region table exceptions

    public class DxfTableException : DxfException
    {
        private readonly string table;

        public DxfTableException(string table, string file)
            : base(file)
        {
            this.table = table;
        }

        public DxfTableException(string table, string file, string message)
            : base(file, message)
        {
            this.table = table;
        }

        public string Table
        {
            get { return this.table; }
        }
    }

    public class InvalidDxfTableException : DxfTableException
    {
        public InvalidDxfTableException(string table, string file)
            : base(table, file)
        {
        }

        public InvalidDxfTableException(string table, string file, string message)
            : base(table, file, message)
        {
        }
    }

    public class OpenDxfTableException : DxfTableException
    {
        public OpenDxfTableException(string table, string file)
            : base(table, file)
        {
        }

        public OpenDxfTableException(string table, string file, string message)
            : base(table, file, message)
        {
        }
    }

    public class ClosedDxfTableException : DxfTableException
    {
        public ClosedDxfTableException(string table, string file)
            : base(table, file)
        {
        }

        public ClosedDxfTableException(string table, string file, string message)
            : base(table, file, message)
        {
        }
    }

    #endregion

    #region entity exceptions

    public class DxfEntityException : DxfException
    {
        private readonly string name;

        public DxfEntityException(string name, string file, string message)
            : base(file, message)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }
    }

    public class DxfInvalidCodeValueEntityException : DxfException
    {
        private readonly int code;
        private readonly string value;

        public DxfInvalidCodeValueEntityException(int code, string value, string file, string message)
            : base(file, message)
        {
            this.code = code;
            this.value = value;
        }

        public int Code
        {
            get { return this.code; }
        }

        public string Value
        {
            get { return this.value; }
        }
    }

    #endregion
}