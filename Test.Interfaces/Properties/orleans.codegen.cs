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

namespace Test.Interfaces
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using System.Collections.Generic;
    using Orleans;
    using Orleans.Runtime;
    using System.Collections;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public class PersonFactory
    {
        

                        public static Test.Interfaces.IPerson GetGrain(long primaryKey)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(Test.Interfaces.IPerson), -627797884, primaryKey));
                        }

                        public static Test.Interfaces.IPerson GetGrain(long primaryKey, string grainClassNamePrefix)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(Test.Interfaces.IPerson), -627797884, primaryKey, grainClassNamePrefix));
                        }

                        public static Test.Interfaces.IPerson GetGrain(System.Guid primaryKey)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(Test.Interfaces.IPerson), -627797884, primaryKey));
                        }

                        public static Test.Interfaces.IPerson GetGrain(System.Guid primaryKey, string grainClassNamePrefix)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(Test.Interfaces.IPerson), -627797884, primaryKey, grainClassNamePrefix));
                        }

            public static Test.Interfaces.IPerson Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return PersonReference.Cast(grainRef);
            }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
        [System.SerializableAttribute()]
        [global::Orleans.CodeGeneration.GrainReferenceAttribute("Test.Interfaces.Test.Interfaces.IPerson")]
        internal class PersonReference : global::Orleans.Runtime.GrainReference, global::Orleans.Runtime.IAddressable, Test.Interfaces.IPerson
        {
            

            public static Test.Interfaces.IPerson Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return (Test.Interfaces.IPerson) global::Orleans.Runtime.GrainReference.CastInternal(typeof(Test.Interfaces.IPerson), (global::Orleans.Runtime.GrainReference gr) => { return new PersonReference(gr);}, grainRef, -627797884);
            }
            
            protected internal PersonReference(global::Orleans.Runtime.GrainReference reference) : 
                    base(reference)
            {
            }
            
            protected internal PersonReference(SerializationInfo info, StreamingContext context) : 
                    base(info, context)
            {
            }
            
            protected override int InterfaceId
            {
                get
                {
                    return -627797884;
                }
            }
            
            protected override string InterfaceName
            {
                get
                {
                    return "Test.Interfaces.Test.Interfaces.IPerson";
                }
            }
            
            [global::Orleans.CodeGeneration.CopierMethodAttribute()]
            public static object _Copier(object original)
            {
                PersonReference input = ((PersonReference)(original));
                return ((PersonReference)(global::Orleans.Runtime.GrainReference.CopyGrainReference(input)));
            }
            
            [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
            public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
            {
                PersonReference input = ((PersonReference)(original));
                global::Orleans.Runtime.GrainReference.SerializeGrainReference(input, stream, expected);
            }
            
            [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
            public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
            {
                return PersonReference.Cast(((global::Orleans.Runtime.GrainReference)(global::Orleans.Runtime.GrainReference.DeserializeGrainReference(expected, stream))));
            }
            
            public override bool IsCompatible(int interfaceId)
            {
                return (interfaceId == this.InterfaceId);
            }
            
            protected override string GetMethodName(int interfaceId, int methodId)
            {
                return PersonMethodInvoker.GetMethodName(interfaceId, methodId);
            }
            
            System.Threading.Tasks.Task<string> Test.Interfaces.IPerson.SayHello()
            {

                return base.InvokeMethodAsync<System.String>(-1732333552, new object[] {} );
            }
            
            System.Threading.Tasks.Task Test.Interfaces.IPerson.SetName(string @firstName, string @lastName)
            {

                return base.InvokeMethodAsync<object>(2085948699, new object[] {@firstName, @lastName} );
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [global::Orleans.CodeGeneration.MethodInvokerAttribute("Test.Interfaces.Test.Interfaces.IPerson", -627797884)]
    internal class PersonMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        
        int global::Orleans.CodeGeneration.IGrainMethodInvoker.InterfaceId
        {
            get
            {
                return -627797884;
            }
        }
        
        global::System.Threading.Tasks.Task<object> global::Orleans.CodeGeneration.IGrainMethodInvoker.Invoke(global::Orleans.Runtime.IAddressable grain, int interfaceId, int methodId, object[] arguments)
        {

            try
            {                    if (grain == null) throw new System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case -627797884:  // IPerson
                        switch (methodId)
                        {
                            case -1732333552: 
                                return ((IPerson)grain).SayHello().ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)t.Result; });
                            case 2085948699: 
                                return ((IPerson)grain).SetName((String)arguments[0], (String)arguments[1]).ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)null; });
                            default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                        }
                    default:
                        throw new System.InvalidCastException("interfaceId="+interfaceId);
                }
            }
            catch(Exception ex)
            {
                var t = new System.Threading.Tasks.TaskCompletionSource<object>();
                t.SetException(ex);
                return t.Task;
            }
        }
        
        public static string GetMethodName(int interfaceId, int methodId)
        {

            switch (interfaceId)
            {
                
                case -627797884:  // IPerson
                    switch (methodId)
                    {
                        case -1732333552:
                            return "SayHello";
                    case 2085948699:
                            return "SetName";
                    
                        default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                    }

                default:
                    throw new System.InvalidCastException("interfaceId="+interfaceId);
            }
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
