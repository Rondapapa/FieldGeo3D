using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FGeo3D_TE
{
    public enum TectureType : byte
    {
        //层面，层理，节理，断层，软弱夹层
        BeddingSurface, Bedding, Joint, Fault, WeakInterbed
    };
    class GeoTecture
    {
        TectureType Tecture { get; set; } //构造类型
        string TectureData { get; set; } //构造类型信息
        GeoAttitude Attitude { get; set; } //构造产状

        GeoTecture(TectureType tectureType, string tectureData, GeoAttitude attitude)
        {
            Tecture = tectureType;
            TectureData = tectureData;
            Attitude = attitude;
        }
    }
}
