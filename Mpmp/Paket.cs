using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp
{
    class Paket
    {
        static byte[] LoginStatusPacket(Int32 status)
        {
            List<byte> tmp = new List<byte>();
            tmp.Add(0x83);
            tmp.AddRange(BitConverter.GetBytes(status));
            return tmp.ToArray();
        }

        static byte[] StartGamePacket(Int32 seed, Int32 unknown, Int32 gameMode, Int32 EntityID, float X, float Y, float Z)
        {
            List<byte> tmp = new List<byte>();
            tmp.Add(0x87);
            tmp.AddRange(BitConverter.GetBytes(seed));
            tmp.AddRange(BitConverter.GetBytes(unknown));
            tmp.AddRange(BitConverter.GetBytes(gameMode));
            tmp.AddRange(BitConverter.GetBytes(EntityID));
            tmp.AddRange(BitConverter.GetBytes(X));
            tmp.AddRange(BitConverter.GetBytes(Y));
            tmp.AddRange(BitConverter.GetBytes(Z));
            return tmp.ToArray();
        }



        static byte[] AddEntityPacket(byte Bytes, int Ineger, byte Bytes2, float X, float Y, float Z, int World, short shortX, short shortY, short shortZ)
        {
            List<byte> tmp = new List<byte>();
            tmp.Add(0x8C);
            tmp.AddRange(BitConverter.GetBytes(Bytes));
            tmp.AddRange(BitConverter.GetBytes(Ineger));
            tmp.AddRange(BitConverter.GetBytes(Bytes2));
            tmp.AddRange(BitConverter.GetBytes(X));
            tmp.AddRange(BitConverter.GetBytes(Y));
            tmp.AddRange(BitConverter.GetBytes(Z));
            tmp.AddRange(BitConverter.GetBytes(World));
            tmp.AddRange(BitConverter.GetBytes(shortX));
            tmp.AddRange(BitConverter.GetBytes(shortY));
            tmp.AddRange(BitConverter.GetBytes(shortZ));
            return tmp.ToArray();
        }

        static byte[] AddItemEntityPacket(int EntityID, short ItemID, byte StackSize, short ItemData, float X, float Y, float Z, byte Yaw, byte Pitch, byte Roll)
        {
            List<byte> tmp = new List<byte>();
            tmp.Add(0x8E);
            tmp.AddRange(BitConverter.GetBytes(X));
            return tmp.ToArray();
        }

        byte[] raw;


        public Paket(byte type, params object[] values)
        {
            List<byte> tmp = new List<byte>();
            for (int i = 0; i < values.Length; i++)
            {
                tmp.AddRange(write(values[i]));
            }
            raw = tmp.ToArray();
        }

        byte[] write(object obj)
        {
            List<byte> tmp = new List<byte>();
            switch (obj.GetType().FullName)
            {
                case "System.Int64":
                    tmp.AddRange(BitConverter.GetBytes((Int64)obj));
                    break;
                case "System.Int32":
                    tmp.AddRange(BitConverter.GetBytes((Int32)obj));
                    break;
                case "System.Int16":
                    tmp.AddRange(BitConverter.GetBytes((short)obj));
                    //short
                    break;
                case "System.Single":
                    tmp.AddRange(BitConverter.GetBytes((float)obj));
                    //float
                    break;
                case "System.Byte":
                    tmp.Add((byte)obj);
                    break;
                case "System.String":
                    string str = (string)obj;
                    short len = (short)Encoding.ASCII.GetByteCount(str);
                    tmp.AddRange(BitConverter.GetBytes(len));
                    tmp.AddRange(Encoding.ASCII.GetBytes(str));
                    break;
                default:
                    tmp.AddRange((byte[])obj);
                    break;
            }
            return tmp.ToArray();
        }

        static byte[] name()
        {
            List<byte> tmp = new List<byte>();
            tmp.Add(0x00);
            return tmp.ToArray();
        }
        //# Minecraft PE 0.7.0 & 0.7.1 alpha Protocol #11

        //# 50 identified Packets
        //[C ==> S] 0x82 LoginPacket (String, int, int, int, String)
        //[C <== S] 0x83 LoginStatusPacket (int)
        //[C ==> S] 0x84 ReadyPacket (bits[8])
        //[C <=> S] 0x85 MessagePacket (String)
        //[C <== S] 0x86 SetTimePacket (int)
        //[C <== S] 0x87 StartGamePacket (int, int, int, int, float, float, float)
        //[C <== S] 0x88 AddMobPacket (int, int, float, float, float, byte, byte, Metadata)
        //[C <== S] 0x89 AddPlayerPacket (GUID, String, int, float, float, float, byte, byte, short, short, Metadata)
        //[C <== S] 0x8A RemovePlayerPacket (int, GUID)

        //[C <== S] 0x8C AddEntityPacket (int, ubyte, float, float, float, int, short, short, short)
        //[C <== S] 0x8D RemoveEntityPacket (int)
        //[C <== S] 0x8E AddItemEntityPacket (int, short, ubyte, short, float, float, float, byte, byte, byte)
        //[C <== S] 0x8F TakeItemEntityPacket (int, int)
        //[C <== S] 0x90 MoveEntityPacket ()

        //[C ??? S] 0x93 MoveEntityPacket_PosRot (int, float, float, float, float, float)
        //[C <=> S] 0x94 MovePlayerPacket (int, float, float, float, float, float)
        //[C ??? S] 0x95 PlaceBlockPacket (int, int, int, ubyte, ubyte, ubyte, ubyte)
        //[C ==> S] 0x96 RemoveBlockPacket (int, int, int, bits[8])
        //[C <== S] 0x97 UpdateBlockPacket (int, int, ubyte, ubyte, ubyte)
        //[C <== S] 0x98 AddPaintingPacket (int, int, int, int, int, String)
        //[C <== S] 0x99 ExplodePacket (float, float, float, float, int, byte, byte, byte)
        //[C <== S] 0x9A LevelEventPacket (short, short, short, short, int)
        //[C <== S] 0x9B TileEventPacket (int, int, int, int, int)
        //[C <=> S] 0x9C EntityEventPacket (int, ubyte)
        //[C ==> S] 0x9D RequestChunkPacket (int, int)
        //[C <== S] 0x9E ChunkDataPacket (int, int, ubyte, Write, Write, Write)
        //[C <=> S] 0x9F PlayerEquipmentPacket (int, ushort, ushort, byte)
        //[C <=> S] 0xA0 PlayerArmorEquipmentPacket (int, byte, byte, byte, byte)
        //[C <=> S] 0xA1 InteractPacket (bits[8], int, int)
        //[C ==> S] 0xA2 UseItemPacket (int, int, int, int, bits[16], bits[8], int, float, float, float, float, float, float)
        //[C ==> S] 0xA3 PlayerActionPacket (int, int, int, int, int, int)

        //[C <== S] 0xA5 HurtArmorPacket (byte)
        //[C <== S] 0xA6 SetEntityDataPacket (int, Metadata)
        //[C <== S] 0xA7 SetEntityMotionPacket (int, short, short, short)
        //[C <== S] 0xA8 SetRidingPacket (int, int)
        //[C <=> S] 0xA9 SetHealthPacket (byte)
        //[C <== S] 0xAA SetSpawnPositionPacket (int, int, ubyte)
        //[C <=> S] 0xAB AnimatePacket (bits[8], int)
        //[C <=> S] 0xAC RespawnPacket (int, float, float, float)
        //[C ==> S] 0xAD SendInventoryPacket (int, ubyte, short, Item, Item)
        //[C ==> S] 0xAE DropItemPacket (int, ubyte, Item)
        //[C <== S] 0xAF ContainerOpenPacket (ubyte, ubyte, ubyte, String)
        //[C <=> S] 0xB0 ContainerClosePacket (ubyte)
        //[C <=> S] 0xB1 ContainerSetSlotPacket (bits[8], bits[16], Item)
        //[C <== S] 0xB2 ContainerSetDataPacket (ubyte, short, short)
        //[C <== S] 0xB3 ContainerSetContentPacket (ubyte, short, Item)
        //[C ??? S] 0xB4 ContainerAckPacket (ubyte, short, Write1, Write0)
        //[C <== S] 0xB5 ChatPacket (String)
        //[C <=> S] 0xB6 SignUpdatePacket (short, ubyte, short, String)
        //[C <== S] 0xB7 AdventureSettingsPacket (bits[32])


    }

}
