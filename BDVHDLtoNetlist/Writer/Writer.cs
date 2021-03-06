using BDVHDLtoNetlist.Block.Chip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDVHDLtoNetlist.Writer
{
    class Writer
    {
        public void Write(Compiler.Compiler compiler, string outputFile)
        {
            var export = new SExpr("expr");
            var components = new SExpr("components");
            var libparts = new SExpr("libparts");
            var nets = new SExpr("nets");

            export.children.AddLast(new SExpr("version", "D"));
            export.children.AddLast(components);
            export.children.AddLast(libparts);
            export.children.AddLast(nets);

            var chipDefinitions = new HashSet<IChipDefinition>();
            foreach (var netComponent in compiler.netComponents)
            {
                var comp = new SExpr("comp");
                comp.children.AddLast(new SExpr("ref", netComponent.name));
                comp.children.AddLast(new SExpr("value", (string)netComponent.chip.chipAttribute["component_name"]));
                comp.children.AddLast(new SExpr("footprint", (string)netComponent.chip.chipAttribute["footprint_name"]));
                comp.children.AddLast(new SExpr("tstamp", netComponent.id.ToString("X8")));
                components.children.AddLast(comp);
                chipDefinitions.Add(netComponent.chip);
            }

            foreach (var chipDefinition in chipDefinitions)
            {
                var libpart = new SExpr("libpart");
                var pins = new SExpr("pins");
                libpart.children.AddLast(new SExpr("lib", (string)chipDefinition.chipAttribute["library_name"]));
                libpart.children.AddLast(new SExpr("part", (string)chipDefinition.chipAttribute["component_name"]));
                libpart.children.AddLast(pins);

                foreach (var mapping in chipDefinition.portNameMappings)
                    foreach (var port in mapping.Values)
                    {
                        var pin = new SExpr("pin");
                        pin.children.AddLast(new SExpr("num", ((int)port.attribute["pin_assign"]).ToString()));
                        pin.children.AddLast(new SExpr("name", port.name.baseName));
                        pin.children.AddLast(new SExpr("type", (string)port.attribute["pin_type"]));
                        pins.children.AddLast(pin);
                    }

                foreach (var constPort in chipDefinition.constAssignMappings.Keys)
                {
                    var pin = new SExpr("pin");
                    pin.children.AddLast(new SExpr("num", ((int)constPort.attribute["pin_assign"]).ToString()));
                    pin.children.AddLast(new SExpr("name", constPort.name.baseName));
                    pin.children.AddLast(new SExpr("type", (string)constPort.attribute["pin_type"]));
                    pins.children.AddLast(pin);
                }

                libparts.children.AddLast(libpart);
            }

            Console.WriteLine(export);
        }
    }
}
