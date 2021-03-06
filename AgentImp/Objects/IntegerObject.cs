﻿using Lextm.SharpSnmpLib.Pipeline;
using Lextm.SharpSnmpLib;
using System;


namespace Carl.Agent
{
    public sealed class IntegerObject : ObjectBase
    {
        private Integer32 _data;
        public override event GetDataFrom GetDataHandler;

        public IntegerObject(string id, string name, Int32 data)
            : base(id)
        {
            _data = new Integer32(data);
            _name = name;
        }

        public IntegerObject(string id, string name):
            base(id)
        {
            _name = name;
        }

        public override ISnmpData Data
        {
            get
            {
                if (GetDataHandler != null)
                {
                    ISnmpData data = GetDataHandler();
                    if (data.TypeCode != SnmpType.Integer32)
                    {
                        throw new ArgumentException("Wrong Type");
                    }
                    return data;
                }
                if (_data != null)
                {
                    return _data;
                }
                else
                {
                    throw new ArgumentNullException("Data");
                }
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                if (value.TypeCode != SnmpType.Integer32)
                {
                    throw new ArgumentException("Wrong Type");
                }

                _data = (Integer32)value;
            }
        }
    }
}