//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998

namespace Test.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using Orleans.CodeGeneration;
    using Orleans;
    using Test.Interfaces;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [SerializableAttribute()]
    [global::Orleans.CodeGeneration.GrainStateAttribute("Test.Collection.Test.Collection.Person")]
    public class PersonState : global::Orleans.CodeGeneration.GrainState, IPersonState
    {
        

            public String @FirstName { get; set; }

            public String @LastName { get; set; }

            public Int32 @OperationCount { get; set; }

            public override void SetAll(System.Collections.Generic.IDictionary<string,object> values)
            {   
                object value;
                if (values == null) { InitStateFields(); return; }
                if (values.TryGetValue("FirstName", out value)) @FirstName = (String) value;
                if (values.TryGetValue("LastName", out value)) @LastName = (String) value;
                if (values.TryGetValue("OperationCount", out value)) @OperationCount = value is Int64 ? (Int32)(Int64)value : (Int32)value;
            }

            public override System.String ToString()
            {
                return System.String.Format("PersonState( FirstName={0} LastName={1} OperationCount={2} )", @FirstName, @LastName, @OperationCount);
            }
        
        public PersonState() : 
                base("Test.Collection.Person")
        {
            this.InitStateFields();
        }
        
        public override System.Collections.Generic.IDictionary<string, object> AsDictionary()
        {
            System.Collections.Generic.Dictionary<string, object> result = new System.Collections.Generic.Dictionary<string, object>();
            result["FirstName"] = this.FirstName;
            result["LastName"] = this.LastName;
            result["OperationCount"] = this.OperationCount;
            return result;
        }
        
        private void InitStateFields()
        {
            this.FirstName = default(String);
            this.LastName = default(String);
            this.OperationCount = default(Int32);
        }
        
        [global::Orleans.CodeGeneration.CopierMethodAttribute()]
        public static object _Copier(object original)
        {
            PersonState input = ((PersonState)(original));
            return input.DeepCopy();
        }
        
        [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
        public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            PersonState input = ((PersonState)(original));
            input.SerializeTo(stream);
        }
        
        [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
        public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            PersonState result = new PersonState();
            result.DeserializeFrom(stream);
            return result;
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
