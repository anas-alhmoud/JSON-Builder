using System;

namespace JSON_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            JSONBuilder JB = new JSONBuilder();

            JB
                .startObj()
                    .key("first_name").value("anas")
                    .key("last_name").value("alhmoud")
                    .key("location").value("riyadh")
                    .key("age").value(23)
                    .key("programming_languages")
                        .startObj()
                            .key("JavaScript").value(true)
                            .key("PHP").value(false)
                            .key("Python").value(true)
                            .key("C#").value()
                        .endObj()
                .endObj();

            Console.WriteLine( JB.get() );
        }
    }

    class JSONBuilder
    {
        private string json;
        private bool pvObj;

        public JSONBuilder startObj()
        {
            json += "{";

            pvObj = false;
            return this;
        }
        public JSONBuilder endObj()
        {
            json += "}";

            return this;
        }

        public JSONBuilder key(string key)
        {
            if (pvObj) json += ", ";
            json += String.Format("\"{0}\": ", key);

            pvObj = true;
            return this;
        }
        public JSONBuilder value(string value)
        {
            json += String.Format("\"{0}\"", value);

            return this;
        }
        public JSONBuilder value(int value)
        {
            json += String.Format("{0}", value);
            return this;
        }
        public JSONBuilder value(bool value)
        {
            json += String.Format("{0}", value).ToLower();
            return this;
        }

        public JSONBuilder value()
        {
            json += "null";
            return this;
        }

        public string get()
        {
            return json;
        }
    }
}
