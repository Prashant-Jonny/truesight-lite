//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Truesight.Parser.Api.Ops
{
    // stelem.i, stelem.i1, stelem.i2, stelem.i4, stelem.i8, stelem.r4, stelem.r8, stelem.ref, stelem
    [global::Truesight.Parser.Impl.Ops.OpCodesAttribute(0x9b, 0x9c, 0x9d, 0x9e, 0x9f, 0xa0, 0xa1, 0xa2, 0xa4)]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public sealed class Stelem : global::Truesight.Parser.Impl.ILOp
    {
        public override global::Truesight.Parser.Api.IILOpType OpType { get { return global::Truesight.Parser.Api.IILOpType.Stelem; } }

        private readonly int _typeToken;

        internal Stelem(global::Truesight.Parser.Impl.MethodBody source, global::System.IO.BinaryReader reader)
            : this(source, reader, global::XenoGears.Functional.EnumerableExtensions.ToReadOnly(global::System.Linq.Enumerable.Empty<global::Truesight.Parser.Impl.ILOp>()))
        {
        }

        internal Stelem(global::Truesight.Parser.Impl.MethodBody source, global::System.IO.BinaryReader reader, global::System.Collections.ObjectModel.ReadOnlyCollection<global::Truesight.Parser.Impl.ILOp> prefixes)
            : base(source, AssertSupportedOpCode(reader), (int)reader.BaseStream.Position - global::System.Linq.Enumerable.Sum(global::System.Linq.Enumerable.Select(prefixes ?? global::XenoGears.Functional.EnumerableExtensions.ToReadOnly(global::System.Linq.Enumerable.Empty<global::Truesight.Parser.Impl.ILOp>()), prefix => prefix.Size)), prefixes ?? global::XenoGears.Functional.EnumerableExtensions.ToReadOnly(global::System.Linq.Enumerable.Empty<global::Truesight.Parser.Impl.ILOp>()))
        {
            // this is necessary for further verification
            var origPos = reader.BaseStream.Position;

            // initializing _typeToken
            switch((ushort)OpSpec.OpCode.Value)
            {
                case 0x9b: //stelem.i
                case 0x9c: //stelem.i1
                case 0x9d: //stelem.i2
                case 0x9e: //stelem.i4
                case 0x9f: //stelem.i8
                case 0xa0: //stelem.r4
                case 0xa1: //stelem.r8
                case 0xa2: //stelem.ref
                    _typeToken = default(int);
                    break;
                case 0xa4: //stelem
                    _typeToken = ReadMetadataToken(reader);
                    break;
                default:
                    throw global::XenoGears.Assertions.AssertionHelper.Fail();
            }

            // verify that we've read exactly the amount of bytes we should
            var bytesRead = reader.BaseStream.Position - origPos;
            global::XenoGears.Assertions.AssertionHelper.AssertTrue(bytesRead == SizeOfOperand);

            // now when the initialization is completed verify that we've got only prefixes we support
            global::XenoGears.Assertions.AssertionHelper.AssertAll(Prefixes, prefix => 
            {
                return false;
            });
        }

        private static global::System.Reflection.Emit.OpCode AssertSupportedOpCode(global::System.IO.BinaryReader reader)
        {
            var opcode = global::Truesight.Parser.Impl.Reader.OpCodeReader.ReadOpCode(reader);
            global::XenoGears.Assertions.AssertionHelper.AssertNotNull(opcode);
            // stelem.i, stelem.i1, stelem.i2, stelem.i4, stelem.i8, stelem.r4, stelem.r8, stelem.ref, stelem
            global::XenoGears.Assertions.AssertionHelper.AssertTrue(global::System.Linq.Enumerable.Contains(new ushort[]{0x9b, 0x9c, 0x9d, 0x9e, 0x9f, 0xa0, 0xa1, 0xa2, 0xa4}, (ushort)opcode.Value.Value));

            return opcode.Value;
        }


        public global::System.Type Type
        {
            get
            {
                switch((ushort)OpSpec.OpCode.Value)
                {
                    case 0x9b: //stelem.i
                        return typeof(global::System.IntPtr);
                    case 0x9c: //stelem.i1
                        return typeof(sbyte);
                    case 0x9d: //stelem.i2
                        return typeof(short);
                    case 0x9e: //stelem.i4
                        return typeof(int);
                    case 0x9f: //stelem.i8
                        return typeof(long);
                    case 0xa0: //stelem.r4
                        return typeof(float);
                    case 0xa1: //stelem.r8
                        return typeof(double);
                    case 0xa2: //stelem.ref
                        return typeof(global::System.Object);
                    case 0xa4: //stelem
                        return TypeFromToken(_typeToken);
                    default:
                        throw global::XenoGears.Assertions.AssertionHelper.Fail();
                }
            }
        }

        public int TypeToken
        {
            get
            {
                switch((ushort)OpSpec.OpCode.Value)
                {
                    case 0x9b: //stelem.i
                    case 0x9c: //stelem.i1
                    case 0x9d: //stelem.i2
                    case 0x9e: //stelem.i4
                    case 0x9f: //stelem.i8
                    case 0xa0: //stelem.r4
                    case 0xa1: //stelem.r8
                    case 0xa2: //stelem.ref
                        return default(int);
                    case 0xa4: //stelem
                        return _typeToken;
                    default:
                        throw global::XenoGears.Assertions.AssertionHelper.Fail();
                }
            }
        }

        public override global::System.String ToString()
        {
            var offset = OffsetToString(Offset) + ":";
            var prefixSpec = Prefixes.Count == 0 ? "" : ("[" + global::XenoGears.Functional.EnumerableExtensions.StringJoin(Prefixes) + "]");
            var name =  "stelem";
            var mods = new global::System.Collections.Generic.List<global::System.String>();
            var modSpec = global::XenoGears.Functional.EnumerableExtensions.StringJoin(global::System.Linq.Enumerable.Where(mods, mod => global::XenoGears.Functional.EnumerableExtensions.IsNeitherNullNorEmpty(mod)), ", ");
            var operand = ((Type != null ? TypeToString(Type) : null) ?? (("0x" + TypeToken.ToString("x8"))));

            var parts = new []{offset, prefixSpec, name, modSpec, operand};
            var result = global::XenoGears.Functional.EnumerableExtensions.StringJoin(global::System.Linq.Enumerable.Where(parts, p => global::XenoGears.Functional.EnumerableExtensions.IsNeitherNullNorEmpty(p)), " ");

            return result;
        }
    }
}