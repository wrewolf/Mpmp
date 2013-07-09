using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpmp
{
    class Packages
    {
        public static readonly byte[] MAGIC = { 0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78 };
        public const byte ID_UNCONNECTED_PING_OPEN_CONNECTIONS = 0x02;
        public const byte ID_OPEN_CONNECTION_REQUEST_1 = 0x05;
        public const byte ID_OPEN_CONNECTION_REPLY_1 = 0x06;
        public const byte ID_OPEN_CONNECTION_REQUEST_2 = 0x07;
        public const byte ID_OPEN_CONNECTION_REPLY_2 = 0x08;
        public const byte ClientConnect = 0x09;
        public const byte Disconnect = 0x15;
        public const byte ID_INCOMPATIBLE_PROTOCOL_VERSION = 0x1A;
        public const byte ID_UNCONNECTED_PING_OPEN_CONNECTIONSs = 0x1C;
        public const byte ID_ADVERTISE_SYSTEM = 0x1D;
        public const byte CUSTOM_PACKET80 = 0x80;
        public const byte CUSTOM_PACKET81 = 0x81;
        public const byte CUSTOM_PACKET82 = 0x82;
        public const byte LoginPacket = 0x82;
        public const byte CUSTOM_PACKET83 = 0x83;
        public const byte LoginStatusPacket = 0x83;
        public const byte CUSTOM_PACKET84 = 0x84;
        public const byte ReadyPacket = 0x84;
        public const byte CUSTOM_PACKET85 = 0x85;
        public const byte CUSTOM_PACKET86 = 0x86;
        public const byte CUSTOM_PACKET87 = 0x87;
        public const byte StartGamePacket = 0x87;
        public const byte CUSTOM_PACKET88 = 0x88;
        public const byte CUSTOM_PACKET89 = 0x89;
        public const byte CUSTOM_PACKET8A = 0x8A;
        public const byte CUSTOM_PACKET8B = 0x8B;
        public const byte CUSTOM_PACKET8C = 0x8C;
        public const byte AddEntityPacket = 0x8C;
        public const byte CUSTOM_PACKET8D = 0x8D;
        public const byte CUSTOM_PACKET8E = 0x8E;
        public const byte AddItemEntityPacket = 0x8E;
        public const byte CUSTOM_PACKET8F = 0x8F;
        public const byte TakeItemEntityPacket = 0x8F;
        public const byte MoveEntityPacket_PosRot = 0x93;
        public const byte MovePlayerPacket = 0x94;
        public const byte PlaceBlockPacket = 0x95;
        public const byte RemoveBlockPacket = 0x96;
        public const byte TileEventPacket = 0x9B;
        public const byte EntityEventPacket = 0x9C;
        public const byte RequestChunkPacket = 0x9D;
        public const byte ChunkDataPacket = 0x9E;
        public const byte PlayerEquipmentPacket = 0x9F;
        public const byte NACK = 0xA0;
        public const byte SetEntityMotionPacket = 0xA4;
        public const byte SetHealthPacket = 0xA5;
        public const byte ACK = 0xC0;




    }

    
}
