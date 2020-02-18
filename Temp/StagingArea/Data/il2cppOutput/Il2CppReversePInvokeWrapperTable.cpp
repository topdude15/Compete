#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <stdint.h>

#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"


// System.Char[]
struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2;
// System.String
struct String_t;
// System.Void
struct Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017;

struct EVENT_FILTER_DESCRIPTOR_t24FD3DB96806FFE8C96FFDB38B1B8331EA0D72BB ;
struct Guid_t ;
struct MLCameraFrameMetadata_t4A0F0FED8F5A2E215DA7455FED424969B7532358 ;
struct MLCameraOutput_t25AD3E1E93800FC37C3CC5133C66E4F76D8D4249_marshaled_pinvoke;
struct MLCameraResultExtras_t68BAF41FA6903A19C39FB979447B19F5AD029EE8 ;
struct MLCea608CaptionSegmentInternal_tEBD5875FB33C013CE4B995BA923A2D93A5112F2A_marshaled_pinvoke;
struct MLInputTabletDeviceState_t093BEE3B9B89570279779CD1E1722C0FA41D9019_marshaled_pinvoke;
struct MLMusicServiceMetadata_t673C0C5D02574580372E1BE6FADAC2790706EB83 ;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Object


// System.ValueType
struct  ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF  : public RuntimeObject
{
public:

public:
};

// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshaled_com
{
};

// System.Enum
struct  Enum_t2AF27C02B8653AE29442467390005ABC74D8F521  : public ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF
{
public:

public:
};

struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_StaticFields
{
public:
	// System.Char[] System.Enum::enumSeperatorCharArray
	CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* ___enumSeperatorCharArray_0;

public:
	inline static int32_t get_offset_of_enumSeperatorCharArray_0() { return static_cast<int32_t>(offsetof(Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_StaticFields, ___enumSeperatorCharArray_0)); }
	inline CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* get_enumSeperatorCharArray_0() const { return ___enumSeperatorCharArray_0; }
	inline CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2** get_address_of_enumSeperatorCharArray_0() { return &___enumSeperatorCharArray_0; }
	inline void set_enumSeperatorCharArray_0(CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* value)
	{
		___enumSeperatorCharArray_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___enumSeperatorCharArray_0), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshaled_com
{
};

// System.IntPtr
struct  IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};


// System.Void
struct  Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017__padding[1];
	};

public:
};


// UnityEngine.XR.MagicLeap.MLCameraError
struct  MLCameraError_t7CF86742DD7F9C879188930E764E36DD17566AAD 
{
public:
	// System.Int32 UnityEngine.XR.MagicLeap.MLCameraError::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MLCameraError_t7CF86742DD7F9C879188930E764E36DD17566AAD, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.XR.MagicLeap.MLInputControllerButton
struct  MLInputControllerButton_tE4AEB5D2358DBE05B0F4927749A1580FE1DA03F1 
{
public:
	// System.UInt32 UnityEngine.XR.MagicLeap.MLInputControllerButton::value__
	uint32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MLInputControllerButton_tE4AEB5D2358DBE05B0F4927749A1580FE1DA03F1, ___value___2)); }
	inline uint32_t get_value___2() const { return ___value___2; }
	inline uint32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(uint32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.XR.MagicLeap.MLInputTabletDeviceButton
struct  MLInputTabletDeviceButton_t44304950E0339CA37FC72C895D6BF46F0F4DD5A2 
{
public:
	// System.UInt32 UnityEngine.XR.MagicLeap.MLInputTabletDeviceButton::value__
	uint32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MLInputTabletDeviceButton_t44304950E0339CA37FC72C895D6BF46F0F4DD5A2, ___value___2)); }
	inline uint32_t get_value___2() const { return ___value___2; }
	inline uint32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(uint32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.XR.MagicLeap.MLMusicServiceErrorType
struct  MLMusicServiceErrorType_t7E113B71776CFB3C05D1281B428459D35A929C46 
{
public:
	// System.UInt32 UnityEngine.XR.MagicLeap.MLMusicServiceErrorType::value__
	uint32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MLMusicServiceErrorType_t7E113B71776CFB3C05D1281B428459D35A929C46, ___value___2)); }
	inline uint32_t get_value___2() const { return ___value___2; }
	inline uint32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(uint32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.XR.MagicLeap.MLMusicServicePlaybackState
struct  MLMusicServicePlaybackState_tF33C2C980B8D9B8855FC631EDCBDA0D768270171 
{
public:
	// System.UInt32 UnityEngine.XR.MagicLeap.MLMusicServicePlaybackState::value__
	uint32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MLMusicServicePlaybackState_tF33C2C980B8D9B8855FC631EDCBDA0D768270171, ___value___2)); }
	inline uint32_t get_value___2() const { return ___value___2; }
	inline uint32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(uint32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.XR.MagicLeap.MLMusicServiceRepeatState
struct  MLMusicServiceRepeatState_t2772503A21DB9B02B64B5A86077AB5657287D7DB 
{
public:
	// System.UInt32 UnityEngine.XR.MagicLeap.MLMusicServiceRepeatState::value__
	uint32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MLMusicServiceRepeatState_t2772503A21DB9B02B64B5A86077AB5657287D7DB, ___value___2)); }
	inline uint32_t get_value___2() const { return ___value___2; }
	inline uint32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(uint32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.XR.MagicLeap.MLMusicServiceShuffleState
struct  MLMusicServiceShuffleState_tD3B918CBEC1B60220DD2E604D190AEC4049AC840 
{
public:
	// System.UInt32 UnityEngine.XR.MagicLeap.MLMusicServiceShuffleState::value__
	uint32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MLMusicServiceShuffleState_tD3B918CBEC1B60220DD2E604D190AEC4049AC840, ___value___2)); }
	inline uint32_t get_value___2() const { return ___value___2; }
	inline uint32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(uint32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.XR.MagicLeap.MLMusicServiceStatus
struct  MLMusicServiceStatus_t28560F7B254677B67029AAF556FFF92D46CBE995 
{
public:
	// System.UInt32 UnityEngine.XR.MagicLeap.MLMusicServiceStatus::value__
	uint32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MLMusicServiceStatus_t28560F7B254677B67029AAF556FFF92D46CBE995, ___value___2)); }
	inline uint32_t get_value___2() const { return ___value___2; }
	inline uint32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(uint32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.XR.MagicLeap.MediaPlayerTracks
struct  MediaPlayerTracks_t182A3267ADF29DEE7D6BBFD1F36B022F76A3CA89 
{
public:
	// System.IntPtr UnityEngine.XR.MagicLeap.MediaPlayerTracks::tracks
	intptr_t ___tracks_0;
	// System.UInt32 UnityEngine.XR.MagicLeap.MediaPlayerTracks::length
	uint32_t ___length_1;

public:
	inline static int32_t get_offset_of_tracks_0() { return static_cast<int32_t>(offsetof(MediaPlayerTracks_t182A3267ADF29DEE7D6BBFD1F36B022F76A3CA89, ___tracks_0)); }
	inline intptr_t get_tracks_0() const { return ___tracks_0; }
	inline intptr_t* get_address_of_tracks_0() { return &___tracks_0; }
	inline void set_tracks_0(intptr_t value)
	{
		___tracks_0 = value;
	}

	inline static int32_t get_offset_of_length_1() { return static_cast<int32_t>(offsetof(MediaPlayerTracks_t182A3267ADF29DEE7D6BBFD1F36B022F76A3CA89, ___length_1)); }
	inline uint32_t get_length_1() const { return ___length_1; }
	inline uint32_t* get_address_of_length_1() { return &___length_1; }
	inline void set_length_1(uint32_t value)
	{
		___length_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

extern "C" void DEFAULT_CALL ReversePInvokeWrapper_EventProvider_EtwEnableCallBack_m32987ABF4E909DC5476F09C034714951CB4A8048(Guid_t * ___sourceId0, int32_t ___controlCode1, uint8_t ___setLevel2, int64_t ___anyKeyword3, int64_t ___allKeyword4, EVENT_FILTER_DESCRIPTOR_t24FD3DB96806FFE8C96FFDB38B1B8331EA0D72BB * ___filterData5, void* ___callbackContext6);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_OSSpecificSynchronizationContext_InvocationEntry_m056BCE43FF155AAE872FF7E565F8F72A50D26147(intptr_t ___arg0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnDeviceAvailableCallback_m02030240D7A448002FB9C18E832C43599EC325E2(intptr_t ___data0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnDeviceUnavailableCallback_m62B700EB5260E6C86F1CE17EA07D8438F559DE52(intptr_t ___data0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnDeviceOpenedCallback_m09B77519422949EAC3F3A3775AADC3191361E75E(intptr_t ___data0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnDeviceClosedCallback_m608677B3D7016289128FC5A2E19ACA47BF49F3BB(intptr_t ___data0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnDeviceDisconnectedCallback_m380826D9B592FAD4A74A3B5A3AFDD9F24D1D6E57(intptr_t ___data0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnDeviceErrorCallback_m930C485571B470F2AD3A9056087F28BA8158A527(int32_t ___error0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnCaptureStartedCallback_m0B4E8494A53E76760DC0EDE627D8F41E436D4985(MLCameraResultExtras_t68BAF41FA6903A19C39FB979447B19F5AD029EE8 * ___extra0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnCaptureFailedCallback_mBBA30D1EF9CCE364CBB799C30DB8B6FA11142B70(MLCameraResultExtras_t68BAF41FA6903A19C39FB979447B19F5AD029EE8 * ___extra0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnCaptureBufferLostCallback_m028497A348156CEB5633DCCF7C33636A1143C784(MLCameraResultExtras_t68BAF41FA6903A19C39FB979447B19F5AD029EE8 * ___extra0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnCaptureProgressedCallback_m13A12AA8950E523764A30E15FE91C77DADE37DCE(uint64_t ___metadataHandle0, MLCameraResultExtras_t68BAF41FA6903A19C39FB979447B19F5AD029EE8 * ___extra1, intptr_t ___data2);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnCaptureCompletedCallback_m3ECC6509968AD03E6F1811B1681F0EF8D8CE7D4B(uint64_t ___metadataHandle0, MLCameraResultExtras_t68BAF41FA6903A19C39FB979447B19F5AD029EE8 * ___extra1, intptr_t ___data2);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnImageBufferAvailableCallback_m38E73C24EC99FE371E97DE33FC0AC64BF595BED4(MLCameraOutput_t25AD3E1E93800FC37C3CC5133C66E4F76D8D4249_marshaled_pinvoke* ___output0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLCamera_OnVideoBufferAvailableCallback_mD9551E56032D0701E7D0DB082659F00F86F554A0(MLCameraOutput_t25AD3E1E93800FC37C3CC5133C66E4F76D8D4249_marshaled_pinvoke* ___output0, MLCameraResultExtras_t68BAF41FA6903A19C39FB979447B19F5AD029EE8 * ___extra1, MLCameraFrameMetadata_t4A0F0FED8F5A2E215DA7455FED424969B7532358 * ___frameMetadata2, intptr_t ___data3);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLInput_OnControllerButtonDownNative_m8219992F1A38D7E7FA0B8347210AC920F96EFCB1(uint8_t ___controllerId0, uint32_t ___button1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLInput_OnControllerButtonUpNative_m846DDCC13FAE1EBA6FAA60B90CA6EA5F278F2EB1(uint8_t ___controllerId0, uint32_t ___button1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLInput_OnControllerConnectNative_mC085E42EC746F220F1C1CA4A45AD0FD0E82E1A3B(uint8_t ___controllerId0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLInput_OnControllerDisconnectNative_mD2FD30B8FBFD6C803B0193998D16EA247A09A6EC(uint8_t ___controllerId0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLInput_OnTabletPenTouchNative_m4C02DAD7A54B49FA81609D94D768A5F489D1F079(uint8_t ___tabletId0, MLInputTabletDeviceState_t093BEE3B9B89570279779CD1E1722C0FA41D9019_marshaled_pinvoke* ___tabletState1, intptr_t ___data2);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLInput_OnTabletRingTouchNative_mB00BC88978B0EFCC5877F9105FA69C8DDE57C755(uint8_t ___tabletId0, int32_t ___touchRingValue1, uint64_t ___timeStamp2, intptr_t ___data3);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLInput_OnTabletButtonDownNative_mE91705076468A3EB823CBEB328408F54433EA7B2(uint8_t ___tabletId0, uint32_t ___tabletButton1, uint64_t ___timeStamp2, intptr_t ___data3);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLInput_OnTabletButtonUpNative_m2F0D5067DC0E34B551BD13225724AD6E1FEE86D5(uint8_t ___tabletId0, uint32_t ___tabletButton1, uint64_t ___timeStamp2, intptr_t ___data3);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLInput_OnTabletConnectNative_m2F15B7A83DD2240AA6D7B2C42178A7E85A7F1E91(uint8_t ___tabletId0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLInput_OnTabletDisconnectNative_m84B0961E62E34692D7381D9412A8FD967924E07D(uint8_t ___tabletId0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMusicService_OnPlaybackStateChangeCallback_m1E4D334351D29456DBB3AADE9864E115D8BF51B0(uint32_t ___state0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMusicService_OnRepeatStateChangeCallback_mFD48DE389250738E9C61217A5913C810B101DDB4(uint32_t ___state0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMusicService_OnShuffleStateChangeCallback_m6FEB95B9806F0411F5993445D654BFD2470F305E(uint32_t ___state0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMusicService_OnMetadataChangeCallback_m2C4576F72B544AF13CD233A4504169EEEEA6B501(MLMusicServiceMetadata_t673C0C5D02574580372E1BE6FADAC2790706EB83 * ___metadata0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMusicService_OnPositionChangeCallback_mC38603F39B31528545EB82CA12264691D3163560(int32_t ___position0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMusicService_OnErrorCallback_m03257089E62EFF1896234EDA5F4F256293E958A1(uint32_t ___errorType0, int32_t ___errorCode1, intptr_t ___data2);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMusicService_OnStatusChangeCallback_m53D3E9E8E99A2E276339EF8C632796B0BF90FE8E(uint32_t ___status0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMusicService_OnVolumeChangeCallback_m7B86C9AD05BB6B4FB570772E91404FBA6BE0F813(float ___volume0, intptr_t ___data1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerPreparedHandler_m39C4C0F5E3204BAD4FAA03C63B2D6416B0D4B20A(int32_t ___mediaPlayerID0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerCompletionHandler_m3377D9729510F9C970803419752870761FE4C6FC(int32_t ___mediaPlayerID0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerBufferingHandler_m1B597EC932172D69F7B04F0EA69D1B375062AA53(int32_t ___percent0, int32_t ___mediaPlayerID1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerErrorHandler_mCDC0FFF7009DAB8147E0BA34E15D85230E4BDDFE(int32_t ___result0, intptr_t ___error1, int32_t ___mediaPlayerID2);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerInfoHandler_mAE9A95B9C5A09D37E46D708E6D0313A23057BBA1(int32_t ___info0, int32_t ___extra1, int32_t ___mediaPlayerID2);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerVideoSizeChangedHandler_m6444791D1773DE1ACEE49D3BFF350F61FD6DE383(int32_t ___width0, int32_t ___height1, int32_t ___mediaPlayerID2);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerTrackDRMInfoHandler_mBDAAB37287AE7DAB9FE33E0C90A7702A22F15495(uint32_t ___DRMTrackIndex0, int32_t ___mediaPlayerID1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerSeekCompletedHandler_m3BB59DF6FB9AEDFC1E9856AA1325E670125DC0DE(int32_t ___mediaPlayerID0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerSubtitleTracksHandler_mBCA53E668D90BB12EF09ECA6155681B31C688CFD(int32_t ___mediaPlayerID0, MediaPlayerTracks_t182A3267ADF29DEE7D6BBFD1F36B022F76A3CA89  ___tracks1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerAllTracksHandler_m4C69974042C10FB1E25A9D052911AFDD568E46CF(int32_t ___mediaPlayerID0, MediaPlayerTracks_t182A3267ADF29DEE7D6BBFD1F36B022F76A3CA89  ___tracks1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerSubtitleInfoHandler_mEF8B97B893ABB2B42CE8BC7149B9483C661630D2(int32_t ___mediaPlayerID0, MLCea608CaptionSegmentInternal_tEBD5875FB33C013CE4B995BA923A2D93A5112F2A_marshaled_pinvoke* ___ccSegInt1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerTimedTextInfoHandler_mBDC916A77C650A21A996FD886875D842202A010C(int32_t ___mediaPlayerID0, intptr_t ___utf8ByteArray1, int64_t ___startTimeMs2, int64_t ___endTimeMs3);


extern const Il2CppMethodPointer g_ReversePInvokeWrapperPointers[];
const Il2CppMethodPointer g_ReversePInvokeWrapperPointers[45] = 
{
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_EventProvider_EtwEnableCallBack_m32987ABF4E909DC5476F09C034714951CB4A8048),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_OSSpecificSynchronizationContext_InvocationEntry_m056BCE43FF155AAE872FF7E565F8F72A50D26147),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnDeviceAvailableCallback_m02030240D7A448002FB9C18E832C43599EC325E2),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnDeviceUnavailableCallback_m62B700EB5260E6C86F1CE17EA07D8438F559DE52),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnDeviceOpenedCallback_m09B77519422949EAC3F3A3775AADC3191361E75E),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnDeviceClosedCallback_m608677B3D7016289128FC5A2E19ACA47BF49F3BB),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnDeviceDisconnectedCallback_m380826D9B592FAD4A74A3B5A3AFDD9F24D1D6E57),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnDeviceErrorCallback_m930C485571B470F2AD3A9056087F28BA8158A527),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnCaptureStartedCallback_m0B4E8494A53E76760DC0EDE627D8F41E436D4985),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnCaptureFailedCallback_mBBA30D1EF9CCE364CBB799C30DB8B6FA11142B70),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnCaptureBufferLostCallback_m028497A348156CEB5633DCCF7C33636A1143C784),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnCaptureProgressedCallback_m13A12AA8950E523764A30E15FE91C77DADE37DCE),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnCaptureCompletedCallback_m3ECC6509968AD03E6F1811B1681F0EF8D8CE7D4B),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnImageBufferAvailableCallback_m38E73C24EC99FE371E97DE33FC0AC64BF595BED4),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLCamera_OnVideoBufferAvailableCallback_mD9551E56032D0701E7D0DB082659F00F86F554A0),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLInput_OnControllerButtonDownNative_m8219992F1A38D7E7FA0B8347210AC920F96EFCB1),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLInput_OnControllerButtonUpNative_m846DDCC13FAE1EBA6FAA60B90CA6EA5F278F2EB1),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLInput_OnControllerConnectNative_mC085E42EC746F220F1C1CA4A45AD0FD0E82E1A3B),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLInput_OnControllerDisconnectNative_mD2FD30B8FBFD6C803B0193998D16EA247A09A6EC),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLInput_OnTabletPenTouchNative_m4C02DAD7A54B49FA81609D94D768A5F489D1F079),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLInput_OnTabletRingTouchNative_mB00BC88978B0EFCC5877F9105FA69C8DDE57C755),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLInput_OnTabletButtonDownNative_mE91705076468A3EB823CBEB328408F54433EA7B2),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLInput_OnTabletButtonUpNative_m2F0D5067DC0E34B551BD13225724AD6E1FEE86D5),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLInput_OnTabletConnectNative_m2F15B7A83DD2240AA6D7B2C42178A7E85A7F1E91),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLInput_OnTabletDisconnectNative_m84B0961E62E34692D7381D9412A8FD967924E07D),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMusicService_OnPlaybackStateChangeCallback_m1E4D334351D29456DBB3AADE9864E115D8BF51B0),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMusicService_OnRepeatStateChangeCallback_mFD48DE389250738E9C61217A5913C810B101DDB4),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMusicService_OnShuffleStateChangeCallback_m6FEB95B9806F0411F5993445D654BFD2470F305E),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMusicService_OnMetadataChangeCallback_m2C4576F72B544AF13CD233A4504169EEEEA6B501),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMusicService_OnPositionChangeCallback_mC38603F39B31528545EB82CA12264691D3163560),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMusicService_OnErrorCallback_m03257089E62EFF1896234EDA5F4F256293E958A1),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMusicService_OnStatusChangeCallback_m53D3E9E8E99A2E276339EF8C632796B0BF90FE8E),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMusicService_OnVolumeChangeCallback_m7B86C9AD05BB6B4FB570772E91404FBA6BE0F813),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerPreparedHandler_m39C4C0F5E3204BAD4FAA03C63B2D6416B0D4B20A),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerCompletionHandler_m3377D9729510F9C970803419752870761FE4C6FC),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerBufferingHandler_m1B597EC932172D69F7B04F0EA69D1B375062AA53),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerErrorHandler_mCDC0FFF7009DAB8147E0BA34E15D85230E4BDDFE),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerInfoHandler_mAE9A95B9C5A09D37E46D708E6D0313A23057BBA1),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerVideoSizeChangedHandler_m6444791D1773DE1ACEE49D3BFF350F61FD6DE383),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerTrackDRMInfoHandler_mBDAAB37287AE7DAB9FE33E0C90A7702A22F15495),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerSeekCompletedHandler_m3BB59DF6FB9AEDFC1E9856AA1325E670125DC0DE),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerSubtitleTracksHandler_mBCA53E668D90BB12EF09ECA6155681B31C688CFD),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerAllTracksHandler_m4C69974042C10FB1E25A9D052911AFDD568E46CF),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerSubtitleInfoHandler_mEF8B97B893ABB2B42CE8BC7149B9483C661630D2),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_MLMediaPlayerLumin_PlayerTimedTextInfoHandler_mBDC916A77C650A21A996FD886875D842202A010C),
};
