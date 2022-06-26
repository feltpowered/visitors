using System;
using System.IO;
using System.Text;
using Felt.Needle.API;
using Mono.Cecil;
using NUnit.Framework;

namespace Felt.Needle.Visitors.Tests
{
    public static class ObfuscationTest
    {
        #region Visitors

        private class ObfTypeVisitor : TypeDefinitionVisitor {
            public override void Visit(TypeDefinition memberDefinition) {
                memberDefinition.Name = GetRandomString(16);
                memberDefinition.Namespace = "";
            }
        }
        
        private class ObfMethodVisitor : MethodDefinitionVisitor {
            public override void Visit(MethodDefinition memberDefinition) {
                memberDefinition.Name = GetRandomString(16);
            }
        }
        
        private class ObfPropertyVisitor : PropertyDefinitionVisitor {
            public override void Visit(PropertyDefinition memberDefinition) {
                memberDefinition.Name = GetRandomString(16);
            }
        }
        
        private class ObfFieldVisitor : FieldDefinitionVisitor {
            public override void Visit(FieldDefinition memberDefinition) {
                memberDefinition.Name = GetRandomString(16);
            }
        }

        #endregion
        
        // Simple test to see if types are successfully renamed.
        [Test]
        public static void ObfuscateAssemblyTest() {
            LoadDummyModule(out IModuleHandler handler, out ModuleDefinition? module);

            if (module is null) {
                Assert.Fail("DummyProject.dll could not be loaded.");
                return;
            }

            VisitorPlugin plugin = new();
            plugin.AddVisitor(new ObfFieldVisitor());
            plugin.AddVisitor(new ObfMethodVisitor());
            plugin.AddVisitor(new ObfPropertyVisitor());
            plugin.AddVisitor(new ObfTypeVisitor());
            
            handler.ModuleTransformer.AddPlugin(plugin);
            handler.TransformModule(module);

            using FileStream stream = File.Open("DummyProject-obf.dll", FileMode.OpenOrCreate);
            handler.ModuleWriter.Write(module, stream);
        }

        private static string GetRandomString(int length) {
            char[] chars = {'I', 'l', '|'};
            
            StringBuilder builder = new();
            Random rand = new();
            
            for (int _ = 0; _ < length; _++) builder.Append(chars[rand.Next(chars.Length)]);

            return builder.ToString();
        }
        
        private static void LoadDummyModule(out IModuleHandler handler, out ModuleDefinition? module)
        {
            handler = new StandardModuleHandler(
                new StandardModuleResolver(),
                new StandardModuleWriter(),
                new StandardModuleTransformer()
            );
            
            module = handler.ModuleResolver.ResolveFromPath("DummyProject.dll");
        }
    }
}