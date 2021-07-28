namespace WpfaAufgabe.Model
{
    public class PropertyModel
    {

        private string _keyName;

        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string KeyName
        {
            get { return _keyName; }
            set { _keyName = value; }
        }

    }
}