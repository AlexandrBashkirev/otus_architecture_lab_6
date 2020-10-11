using System;
using System.Collections.Generic;


namespace otus_architecture_lab_6
{
    class CmdParser
    {
        #region Variables

        private Dictionary<string, string> args = new Dictionary<string, string>();

        #endregion



        #region Methods

        public CmdParser Init(string[] args)
        {
            if(args.Length % 2 != 0)
            {
                throw new Exception("only double parameters avalible");
            }

            for(int i = 0; i < args.Length; i += 2)
            {
                if(args[i].Contains("-"))
                {
                    this.args.Add(args[i], args[i + 1]);
                }
                else
                {
                    throw new Exception("wrong parametrs format");
                }
            }

            return this;
        }


        public string GetValue(string key)
        {
            if(args.ContainsKey(key))
            {
                return args[key];
            }

            return null;
        }

        #endregion
    }
}
