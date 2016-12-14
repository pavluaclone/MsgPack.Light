using System;
using System.Linq;
using System.Linq.Expressions;
// ReSharper disable once RedundantUsingDirective
using System.Reflection;

namespace ProGaudi.MsgPack.Light
{
    public class CompiledLambdaActivatorFactory
    {
        public static Func<object> GetActivator(Type type)
        {
#if PROGAUDI_NETCORE
            var ctor = type.GetTypeInfo().DeclaredConstructors.First(x => x.GetParameters().Length == 0 && !x.IsStatic);
#else
            var ctor = type.GetConstructor(Type.EmptyTypes);
#endif

            //make a NewExpression that calls the
            //ctor with the args we just created
            var newExp = Expression.New(ctor);

            //create a lambda with the New
            //Expression as body and our param object[] as arg
            var lambda = Expression.Lambda(typeof(Func<object>), newExp);

            //compile it
            return (Func<object>)lambda.Compile();
        }
    }
}
