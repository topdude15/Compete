#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif



#include "codegen/il2cpp-codegen-metadata.h"





IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END




// 0x00000001 UnityEngine.XR.MagicLeap.MLResult IMediaPlayer::CreateStreamingMediaPlayer(UnityEngine.GameObject,System.String,System.Int32)
// 0x00000002 System.Boolean IMediaPlayer::CreateTexture(UnityEngine.Renderer,System.Int32)
// 0x00000003 UnityEngine.XR.MagicLeap.MLResult IMediaPlayer::Play(System.Int32)
// 0x00000004 UnityEngine.XR.MagicLeap.MLResult IMediaPlayer::PauseVideo(System.Int32)
// 0x00000005 UnityEngine.XR.MagicLeap.MLResult IMediaPlayer::Seek(System.Int32,System.Int32)
// 0x00000006 UnityEngine.XR.MagicLeap.MLResult IMediaPlayer::SetVolume(System.Single,System.Int32)
// 0x00000007 UnityEngine.XR.MagicLeap.MLResult IMediaPlayer::Stop(System.Int32)
// 0x00000008 UnityEngine.XR.MagicLeap.MLResult IMediaPlayer::Resume(System.Int32)
// 0x00000009 UnityEngine.XR.MagicLeap.MLResult IMediaPlayer::SetLooping(System.Boolean,System.Int32)
// 0x0000000A UnityEngine.XR.MagicLeap.MLResult IMediaPlayer::Cleanup(System.Int32)
// 0x0000000B UnityEngine.XR.MagicLeap.MLResult IMediaPlayer::SelectSubtitleTrack(System.Int32,System.UInt32)
// 0x0000000C UnityEngine.XR.MagicLeap.MLResult IMediaPlayer::UnselectSubtitleTrack(System.Int32,System.UInt32)
// 0x0000000D System.Collections.Generic.Dictionary`2<System.Int64,UnityEngine.XR.MagicLeap.TrackData> IMediaPlayer::GetAllTrackInfo(System.Int32)
// 0x0000000E System.Boolean IMediaPlayer::RequestActivationKeyRequest(System.Byte[],System.Action`3<UnityEngine.XR.MagicLeap.MLResult,System.Byte[],System.String>)
// 0x0000000F System.Int32 IMediaPlayer::GetDurationMilliseconds(System.Int32)
// 0x00000010 System.Int32 IMediaPlayer::GetPositionMilliseconds(System.Int32)
// 0x00000011 System.Int32 IMediaPlayer::GetWidth(System.Int32)
// 0x00000012 System.Int32 IMediaPlayer::GetHeight(System.Int32)
// 0x00000013 UnityEngine.Rect IMediaPlayer::GetResolution(System.Int32)
// 0x00000014 System.Int32 IMediaPlayer::GetVideoBitrate(System.Int32)
// 0x00000015 System.Void IMediaPlayer::SetLicenseServer(System.String)
// 0x00000016 System.Void IMediaPlayer::SetCustomLicenseHeaderData(System.Collections.Generic.Dictionary`2<System.String,System.String>)
// 0x00000017 System.Void IMediaPlayer::SetCustomLicenseMessageData(System.Collections.Generic.Dictionary`2<System.String,System.String>)
// 0x00000018 System.Void IMediaPlayer::SetCustomLicenseRequestBuilder(System.Func`3<UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[],System.Byte[]>)
// 0x00000019 System.Void IMediaPlayer::SetCustomLicenseResponseParser(System.Func`3<UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[],System.Byte[]>)
// 0x0000001A System.UInt64 IMediaPlayer::GetFrameDropThresholdMs(System.Int32)
// 0x0000001B System.Void IMediaPlayer::SetFrameDropThresholdMs(System.Int32,System.UInt64)
// 0x0000001C System.IntPtr MagicLeapInternal.MediaPlayerNativeBindings::GetRenderCallback()
extern void MediaPlayerNativeBindings_GetRenderCallback_mC918271C533676217DDF54EAD94F61EDE197E2A2 ();
// 0x0000001D System.IntPtr MagicLeapInternal.MediaPlayerNativeBindings::GetRenderCleanupCallback()
extern void MediaPlayerNativeBindings_GetRenderCleanupCallback_mC32A08F859C642169357F7C8640BD9A3D4CE9859 ();
// 0x0000001E System.Void MagicLeapInternal.MediaPlayerNativeBindings::SetTextureFromUnity(System.IntPtr,System.Int32,System.Int32,System.Int32)
extern void MediaPlayerNativeBindings_SetTextureFromUnity_mCBC0A349878CF031C3B54DD430F2F5663E21AF88 ();
// 0x0000001F UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::SetupStreamingMediaPlayer(MagicLeapInternal.MediaPlayerNativeBindings_PlayerReadyCallback,MagicLeapInternal.MediaPlayerNativeBindings_PlayerCompleteCallback,MagicLeapInternal.MediaPlayerNativeBindings_PlayerBufferingCallback,MagicLeapInternal.MediaPlayerNativeBindings_PlayerErrorCallback,MagicLeapInternal.MediaPlayerNativeBindings_PlayerInfoCallback,MagicLeapInternal.MediaPlayerNativeBindings_PlayerVideoSizeChangedCallback,MagicLeapInternal.MediaPlayerNativeBindings_PlayerTrackDRMInfoCallback,MagicLeapInternal.MediaPlayerNativeBindings_PlayerSeekCompletedCallback,MagicLeapInternal.MediaPlayerNativeBindings_PlayerSubtitleTracksCallback,MagicLeapInternal.MediaPlayerNativeBindings_PlayerSubtitleDataCallback,MagicLeapInternal.MediaPlayerNativeBindings_PlayerTimedTextInfoCallback,MagicLeapInternal.MediaPlayerNativeBindings_PlayerTracksCallback,System.String,System.Int32,MagicLeapInternal.MediaPlayerNativeBindings_MLMediaColorSpace)
extern void MediaPlayerNativeBindings_SetupStreamingMediaPlayer_mDC866F61512933F5C8D5E217872E30DCBFF14E79 ();
// 0x00000020 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::OpenDRMSession(System.Int32,UnityEngine.XR.MagicLeap.MLMediaDRMTrack)
extern void MediaPlayerNativeBindings_OpenDRMSession_mFD4E2D02E8B68AD931397094A0FABB057CB8D31F ();
// 0x00000021 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::CloseDRMSession(System.Int32,UnityEngine.XR.MagicLeap.MLMediaDRMTrack)
extern void MediaPlayerNativeBindings_CloseDRMSession_m66FD45CF0C2EBCBBD4F2C0E3B9740F676A248464 ();
// 0x00000022 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::SetKeyRequestCustomData(System.Int32,UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.String[],System.String[],System.UInt64)
extern void MediaPlayerNativeBindings_SetKeyRequestCustomData_mC236F7A2FD824F18048B61B660C366E2DF740F1D ();
// 0x00000023 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::GetProvisionRequest(System.Int32,System.String,System.IntPtr&,System.UInt64&,System.String&)
extern void MediaPlayerNativeBindings_GetProvisionRequest_m6EDEBD4F432D42C5FE23C6B638F76E4829B72951 ();
// 0x00000024 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::ProvideProvisionResponse(System.Int32,System.Byte[],System.UInt64)
extern void MediaPlayerNativeBindings_ProvideProvisionResponse_m0EA1405AA3CE84447B9EF2925643DE9F0E6936E3 ();
// 0x00000025 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::GetActivationProvisionRequest(System.String,System.IntPtr&,System.UInt64&,System.String&)
extern void MediaPlayerNativeBindings_GetActivationProvisionRequest_m7504509FAA1E08109CC1916104EE8C11EA7BE7F5 ();
// 0x00000026 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::ProvideActivationProvisionResponse(System.Byte[],System.UInt64)
extern void MediaPlayerNativeBindings_ProvideActivationProvisionResponse_mC801CDC4D63DE648CD823CEBFB4CA4E8F9BFB2D2 ();
// 0x00000027 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::GetActivationKeyRequest(MagicLeapInternal.MagicLeapNativeBindings_MLUUIDBytes&,UnityEngine.XR.MagicLeap.MLMediaDRMKeyType,System.IntPtr&,System.UInt64&,System.String&)
extern void MediaPlayerNativeBindings_GetActivationKeyRequest_mB034D4E68BDDD0CD68709BC21677A44457BF4AE8 ();
// 0x00000028 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::GetKeyRequest(System.Int32,UnityEngine.XR.MagicLeap.MLMediaDRMTrack,UnityEngine.XR.MagicLeap.MLMediaDRMKeyType,System.IntPtr&,System.UInt64&,System.String&)
extern void MediaPlayerNativeBindings_GetKeyRequest_m1DC68B6965256F35A41FCDECA3CA91613C8F1E41 ();
// 0x00000029 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::ProvideKeyResponse(System.Int32,UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[],System.UInt64)
extern void MediaPlayerNativeBindings_ProvideKeyResponse_m2B819CC6DC69FD531F49B551DA911ED0BD16005B ();
// 0x0000002A UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::PrepareDRM(System.Int32,UnityEngine.XR.MagicLeap.MLMediaDRMTrack)
extern void MediaPlayerNativeBindings_PrepareDRM_m82AFD6A1C0DF3028357D0387998255CD840CC008 ();
// 0x0000002B UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::Play(System.Int32)
extern void MediaPlayerNativeBindings_Play_m036F47AEB96EB3E22750EFCDEBFD8E1A84550838 ();
// 0x0000002C UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::PauseVideo(System.Int32)
extern void MediaPlayerNativeBindings_PauseVideo_m3EFF5CCE24928960E21B6A41E4EEDA2FEBD96540 ();
// 0x0000002D UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::Seek(System.Int32,System.Int32)
extern void MediaPlayerNativeBindings_Seek_m82D41B649F13A883A7070E2421CCE66236E95D05 ();
// 0x0000002E UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::Cleanup(System.Int32)
extern void MediaPlayerNativeBindings_Cleanup_m6B161A0372892A6AF774696DAA62107FEC86F32D ();
// 0x0000002F UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::SetVolume(System.Single,System.Int32)
extern void MediaPlayerNativeBindings_SetVolume_mB84467B9BDD256F28A161AEBDCC4B41261D5EFDE ();
// 0x00000030 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::Stop(System.Int32)
extern void MediaPlayerNativeBindings_Stop_m2EDA0944ACFC2574930FDF9E70599C43D2F7DE0F ();
// 0x00000031 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::Resume(System.Int32)
extern void MediaPlayerNativeBindings_Resume_m8EBFCDC43AFA0CF7D0AA1C9B7F276A30360E13D3 ();
// 0x00000032 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::GetDurationMilliseconds(System.Int32,System.Int32&)
extern void MediaPlayerNativeBindings_GetDurationMilliseconds_m7D038B8EA60AA811EB080778F176D0235EBB8D55 ();
// 0x00000033 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::GetPositionMilliseconds(System.Int32,System.Int32&)
extern void MediaPlayerNativeBindings_GetPositionMilliseconds_m62E34E426EE1B0A993843BED012FBED9F1D61B20 ();
// 0x00000034 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::GetWidth(System.Int32,System.Int32&)
extern void MediaPlayerNativeBindings_GetWidth_m03BF536B09785849A6F87F7EB86F5998997B2683 ();
// 0x00000035 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::GetHeight(System.Int32,System.Int32&)
extern void MediaPlayerNativeBindings_GetHeight_m9141E73E8A6BB6C55B174CD12A06484E4D7ED3E4 ();
// 0x00000036 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::SetLooping(System.Int32,System.Boolean)
extern void MediaPlayerNativeBindings_SetLooping_m5052795E3CE69D235BA356B1E0020E9FCC8DEAC8 ();
// 0x00000037 System.UInt64 MagicLeapInternal.MediaPlayerNativeBindings::GetFrameDropThresholdMs(System.Int32)
extern void MediaPlayerNativeBindings_GetFrameDropThresholdMs_m09C1FF36343A50C098004EB2DB6A250E0D99B5D7 ();
// 0x00000038 System.Void MagicLeapInternal.MediaPlayerNativeBindings::SetFrameDropThresholdMs(System.Int32,System.UInt64)
extern void MediaPlayerNativeBindings_SetFrameDropThresholdMs_mCE4D75F25B36416F98B9F2B33331BDF19F943096 ();
// 0x00000039 UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::GetVideoBitrate(System.Int32,System.Int32&)
extern void MediaPlayerNativeBindings_GetVideoBitrate_m06332D28FC93DACE55B9C0A1FD0F36D80F30CCAA ();
// 0x0000003A UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::GetTrackData(System.Int32)
extern void MediaPlayerNativeBindings_GetTrackData_mE045BF65E0B4B4C03F7FE85A6B37AC4F4DD3E514 ();
// 0x0000003B UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::GetSubtitleTracks(System.Int32,UnityEngine.XR.MagicLeap.SubtitleInfo)
extern void MediaPlayerNativeBindings_GetSubtitleTracks_m8C4F3050506DD365E317587B14611DD383B53D77 ();
// 0x0000003C UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::SelectSubtitleTrack(System.Int32,System.UInt32)
extern void MediaPlayerNativeBindings_SelectSubtitleTrack_m3A89885770007F89EEBECD5BF3803B304FE52240 ();
// 0x0000003D UnityEngine.XR.MagicLeap.MLResultCode MagicLeapInternal.MediaPlayerNativeBindings::UnselectSubtitleTrack(System.Int32,System.UInt32)
extern void MediaPlayerNativeBindings_UnselectSubtitleTrack_m3556DC8BDF084FF38F0AC8B54758D1003484A5EB ();
// 0x0000003E System.Void MagicLeapInternal.MediaPlayerNativeBindings::.ctor()
extern void MediaPlayerNativeBindings__ctor_m119041C7D50664069E7B697614F5C4F05F0DB325 ();
// 0x0000003F System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerReadyCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerReadyCallback__ctor_m459619B1D557A228A4475A109ABC045DC98F5AF2 ();
// 0x00000040 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerReadyCallback::Invoke(System.Int32)
extern void PlayerReadyCallback_Invoke_mB6EC20EEFEC46FE297F69530E95A4598B4627409 ();
// 0x00000041 System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerReadyCallback::BeginInvoke(System.Int32,System.AsyncCallback,System.Object)
extern void PlayerReadyCallback_BeginInvoke_mBAC986DF572F99C52EEA22E2AF4852EAD938BF65 ();
// 0x00000042 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerReadyCallback::EndInvoke(System.IAsyncResult)
extern void PlayerReadyCallback_EndInvoke_m78CBECD6AA5F2270BE70E9A9D406077E42CA572C ();
// 0x00000043 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerCompleteCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerCompleteCallback__ctor_m6542958FC8009BFB7646E65D276313C60879B270 ();
// 0x00000044 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerCompleteCallback::Invoke(System.Int32)
extern void PlayerCompleteCallback_Invoke_m42FA0946F70DF3BF0C485952735A72F47C381151 ();
// 0x00000045 System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerCompleteCallback::BeginInvoke(System.Int32,System.AsyncCallback,System.Object)
extern void PlayerCompleteCallback_BeginInvoke_m17582FC9EB7ABA15DA849999274F32060B46FB1A ();
// 0x00000046 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerCompleteCallback::EndInvoke(System.IAsyncResult)
extern void PlayerCompleteCallback_EndInvoke_mAC875DB7A8073379E12CD2775D4E3AF58C5C0E16 ();
// 0x00000047 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerBufferingCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerBufferingCallback__ctor_mC3367D0F209CECA05DA81F603DB9897D1E88251F ();
// 0x00000048 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerBufferingCallback::Invoke(System.Int32,System.Int32)
extern void PlayerBufferingCallback_Invoke_mECE347C13C26570554C6FA92D4D1BC819E75EE4D ();
// 0x00000049 System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerBufferingCallback::BeginInvoke(System.Int32,System.Int32,System.AsyncCallback,System.Object)
extern void PlayerBufferingCallback_BeginInvoke_m33A13C27799226CE6457CC871F342ED41CD9DD21 ();
// 0x0000004A System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerBufferingCallback::EndInvoke(System.IAsyncResult)
extern void PlayerBufferingCallback_EndInvoke_m60F6812F6448EA533E596998D115A5B69EF260B6 ();
// 0x0000004B System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerErrorCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerErrorCallback__ctor_mF24AB55968D2B31E2256B086B72045BBE06487A3 ();
// 0x0000004C System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerErrorCallback::Invoke(System.Int32,System.IntPtr,System.Int32)
extern void PlayerErrorCallback_Invoke_m70F3619C8523C9A78B94256F5EE108728556EE51 ();
// 0x0000004D System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerErrorCallback::BeginInvoke(System.Int32,System.IntPtr,System.Int32,System.AsyncCallback,System.Object)
extern void PlayerErrorCallback_BeginInvoke_m2083FEA0BDFAE2B94399C8C0EAF90A2A53F1A905 ();
// 0x0000004E System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerErrorCallback::EndInvoke(System.IAsyncResult)
extern void PlayerErrorCallback_EndInvoke_m7031BF6B4DE50B8A09B7660DBE01B60C4DF60F2D ();
// 0x0000004F System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerInfoCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerInfoCallback__ctor_m10C18134F648DCCE83132019D0DDE34E71C84FE8 ();
// 0x00000050 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerInfoCallback::Invoke(System.Int32,System.Int32,System.Int32)
extern void PlayerInfoCallback_Invoke_mE76A31AA416067DA8207956AB2067516B101D10C ();
// 0x00000051 System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerInfoCallback::BeginInvoke(System.Int32,System.Int32,System.Int32,System.AsyncCallback,System.Object)
extern void PlayerInfoCallback_BeginInvoke_mBE8CEAA6B11C838C4F0639D25EC076EFD734514F ();
// 0x00000052 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerInfoCallback::EndInvoke(System.IAsyncResult)
extern void PlayerInfoCallback_EndInvoke_m248574F9404EC5908029FFEAD90FABF551464132 ();
// 0x00000053 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerVideoSizeChangedCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerVideoSizeChangedCallback__ctor_m066C5446637425B769600DC781705194656A54E8 ();
// 0x00000054 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerVideoSizeChangedCallback::Invoke(System.Int32,System.Int32,System.Int32)
extern void PlayerVideoSizeChangedCallback_Invoke_m84AE578A67E06D9FD5EDEC22E19A986B105AB862 ();
// 0x00000055 System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerVideoSizeChangedCallback::BeginInvoke(System.Int32,System.Int32,System.Int32,System.AsyncCallback,System.Object)
extern void PlayerVideoSizeChangedCallback_BeginInvoke_m1BEB5C7CAA35DED901608329DC88974C47D7E3A3 ();
// 0x00000056 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerVideoSizeChangedCallback::EndInvoke(System.IAsyncResult)
extern void PlayerVideoSizeChangedCallback_EndInvoke_m2D6A15954A1F7F6AD340BB3E6BDFFD728D5BD5F2 ();
// 0x00000057 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerTrackDRMInfoCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerTrackDRMInfoCallback__ctor_m39B3EC9E2BA2B14837F10938AEDA755A1FF52716 ();
// 0x00000058 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerTrackDRMInfoCallback::Invoke(System.UInt32,System.Int32)
extern void PlayerTrackDRMInfoCallback_Invoke_m652E011746771DE19AF2FF3A3E95F9284D6A2B46 ();
// 0x00000059 System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerTrackDRMInfoCallback::BeginInvoke(System.UInt32,System.Int32,System.AsyncCallback,System.Object)
extern void PlayerTrackDRMInfoCallback_BeginInvoke_m22CF5B2BC9238573DF3BC716AD0749085AD9D8B5 ();
// 0x0000005A System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerTrackDRMInfoCallback::EndInvoke(System.IAsyncResult)
extern void PlayerTrackDRMInfoCallback_EndInvoke_m8B432621EE3884135FAB14279239E8906D35ED72 ();
// 0x0000005B System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerSeekCompletedCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerSeekCompletedCallback__ctor_m217AE793BC39B95611645505304F21B0DB85535E ();
// 0x0000005C System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerSeekCompletedCallback::Invoke(System.Int32)
extern void PlayerSeekCompletedCallback_Invoke_m80B412BFF5F6261A9ABCC849616B62E3512022EF ();
// 0x0000005D System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerSeekCompletedCallback::BeginInvoke(System.Int32,System.AsyncCallback,System.Object)
extern void PlayerSeekCompletedCallback_BeginInvoke_m3B559EE4B5E4AA853E9E941A1A9766FFE0F0E4C2 ();
// 0x0000005E System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerSeekCompletedCallback::EndInvoke(System.IAsyncResult)
extern void PlayerSeekCompletedCallback_EndInvoke_mE09312DF428427AA896BC0CBDEA0D0BA07D6E739 ();
// 0x0000005F System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerSubtitleTracksCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerSubtitleTracksCallback__ctor_mC571D28B80AAE33F0C2B15D9FD9B7AAFC38B289F ();
// 0x00000060 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerSubtitleTracksCallback::Invoke(System.Int32,UnityEngine.XR.MagicLeap.SubtitleInfo)
extern void PlayerSubtitleTracksCallback_Invoke_m84F45288862BFF03CF9B7E299486D9D3FF2E125C ();
// 0x00000061 System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerSubtitleTracksCallback::BeginInvoke(System.Int32,UnityEngine.XR.MagicLeap.SubtitleInfo,System.AsyncCallback,System.Object)
extern void PlayerSubtitleTracksCallback_BeginInvoke_m7DCB406A2EC9D7238B545A7EBD3CE6BBCF4C66F9 ();
// 0x00000062 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerSubtitleTracksCallback::EndInvoke(System.IAsyncResult)
extern void PlayerSubtitleTracksCallback_EndInvoke_mC87531A8480AD66F91491519B1B049CCD0F413D9 ();
// 0x00000063 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerTracksCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerTracksCallback__ctor_mE056B6B7581FBF6C4D8CC4CFBDC9E7A34E32FE37 ();
// 0x00000064 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerTracksCallback::Invoke(System.Int32,System.IntPtr,System.Int32)
extern void PlayerTracksCallback_Invoke_m6EA8E3C44E68AFAB7FF6FC804C2BB1B4F71D5D39 ();
// 0x00000065 System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerTracksCallback::BeginInvoke(System.Int32,System.IntPtr,System.Int32,System.AsyncCallback,System.Object)
extern void PlayerTracksCallback_BeginInvoke_m58835DC3B2917D34DDBEAAB0967585DAB2524E7E ();
// 0x00000066 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerTracksCallback::EndInvoke(System.IAsyncResult)
extern void PlayerTracksCallback_EndInvoke_m239B8666D6DE4925A92C0806EAD0457B93B5A32A ();
// 0x00000067 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerSubtitleDataCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerSubtitleDataCallback__ctor_m60A04B83836BE2A50A3221F428472C22C48DAF18 ();
// 0x00000068 System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerSubtitleDataCallback::Invoke(System.Int32,UnityEngine.XR.MagicLeap.MLCea608CaptionSegmentInternal&)
extern void PlayerSubtitleDataCallback_Invoke_mB0ACC46EEBD6EDF1F45124EAB04AEE5D81B68E8F ();
// 0x00000069 System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerSubtitleDataCallback::BeginInvoke(System.Int32,UnityEngine.XR.MagicLeap.MLCea608CaptionSegmentInternal&,System.AsyncCallback,System.Object)
extern void PlayerSubtitleDataCallback_BeginInvoke_m092FF929A0444DEE1D17B080EEACF6C69F1B12BD ();
// 0x0000006A System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerSubtitleDataCallback::EndInvoke(UnityEngine.XR.MagicLeap.MLCea608CaptionSegmentInternal&,System.IAsyncResult)
extern void PlayerSubtitleDataCallback_EndInvoke_m345068E37B7AA5071A5D9E46977998BD3412EA25 ();
// 0x0000006B System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerTimedTextInfoCallback::.ctor(System.Object,System.IntPtr)
extern void PlayerTimedTextInfoCallback__ctor_m9E27EAAB0720CBFFB30C6A763E818EB8BC20F3AE ();
// 0x0000006C System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerTimedTextInfoCallback::Invoke(System.Int32,System.IntPtr,System.Int64,System.Int64)
extern void PlayerTimedTextInfoCallback_Invoke_m563B9EBF05A9B1769DEB1700D9FE0D6258C15868 ();
// 0x0000006D System.IAsyncResult MagicLeapInternal.MediaPlayerNativeBindings_PlayerTimedTextInfoCallback::BeginInvoke(System.Int32,System.IntPtr,System.Int64,System.Int64,System.AsyncCallback,System.Object)
extern void PlayerTimedTextInfoCallback_BeginInvoke_m846698EDDE7B2C6B16F2A502331FACD9CACBD2BB ();
// 0x0000006E System.Void MagicLeapInternal.MediaPlayerNativeBindings_PlayerTimedTextInfoCallback::EndInvoke(System.IAsyncResult)
extern void PlayerTimedTextInfoCallback_EndInvoke_m2BEA933D46CA2C7DB07787996D90233D2FE68C9C ();
// 0x0000006F System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::TryApplyStereoMode(System.String)
extern void MLMediaPlayer_TryApplyStereoMode_mD8BE7E97A6CA1609C235ED3F8789F82D62D4FEDF ();
// 0x00000070 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::ApplyVideoRenderMaterial(System.String)
extern void MLMediaPlayer_ApplyVideoRenderMaterial_mFB6EA50CEBBFBF8DED1FFED7CC62908CAFB4D5DE ();
// 0x00000071 UnityEngine.Material UnityEngine.XR.MagicLeap.MLMediaPlayer::get_VideoRenderMaterial()
extern void MLMediaPlayer_get_VideoRenderMaterial_m6DE1AB32E0346B9B4EEEC6D092BDB23B3AFFE290 ();
// 0x00000072 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_VideoRenderMaterial(UnityEngine.Material)
extern void MLMediaPlayer_set_VideoRenderMaterial_m559BE47832A378E601B3C6C6921156E20A25FD15 ();
// 0x00000073 UnityEngine.XR.MagicLeap.MLMediaPlayer_VideoStereoMode UnityEngine.XR.MagicLeap.MLMediaPlayer::get_StereoMode()
extern void MLMediaPlayer_get_StereoMode_m91665472BEED336310A92D0EC753E0089D23A2FE ();
// 0x00000074 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_StereoMode(UnityEngine.XR.MagicLeap.MLMediaPlayer_VideoStereoMode)
extern void MLMediaPlayer_set_StereoMode_mB18B9849668F74BEB84E7B6063A8E81010302515 ();
// 0x00000075 System.String UnityEngine.XR.MagicLeap.MLMediaPlayer::get_VideoSource()
extern void MLMediaPlayer_get_VideoSource_m17AD68FCA8A6CD5076EDE6F75CEC58B8D542F85A ();
// 0x00000076 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_VideoSource(System.String)
extern void MLMediaPlayer_set_VideoSource_m964049C6DE88D5044D7989D1E544E7EB9196BE71 ();
// 0x00000077 System.String UnityEngine.XR.MagicLeap.MLMediaPlayer::get_LicenseServer()
extern void MLMediaPlayer_get_LicenseServer_m30D6773E0985AA1B103EEAFA5DD47D0B168C5184 ();
// 0x00000078 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_LicenseServer(System.String)
extern void MLMediaPlayer_set_LicenseServer_mAC146A56ADDE2A214FDF95390626C6DC3E2B6966 ();
// 0x00000079 System.Collections.Generic.Dictionary`2<System.String,System.String> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_CustomLicenseHeaderData()
extern void MLMediaPlayer_get_CustomLicenseHeaderData_m625F9408305DC24C21B4AAAA14B82A7FF3E22D35 ();
// 0x0000007A System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_CustomLicenseHeaderData(System.Collections.Generic.Dictionary`2<System.String,System.String>)
extern void MLMediaPlayer_set_CustomLicenseHeaderData_mA46EA7A3BAAE49D626B4F902B4AC2F50E277AEA9 ();
// 0x0000007B System.Collections.Generic.Dictionary`2<System.String,System.String> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_CustomLicenseMessageData()
extern void MLMediaPlayer_get_CustomLicenseMessageData_m89BF9501F6CAFA11E04FBA200E47CB192F585409 ();
// 0x0000007C System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_CustomLicenseMessageData(System.Collections.Generic.Dictionary`2<System.String,System.String>)
extern void MLMediaPlayer_set_CustomLicenseMessageData_m450555E93910DD936BFBA899DB2187D14DB53B48 ();
// 0x0000007D System.Func`3<UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[],System.Byte[]> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_CustomLicenseRequestBuilder()
extern void MLMediaPlayer_get_CustomLicenseRequestBuilder_m556BCE2B73FDAA6693A8A8896B3F4E319E839D49 ();
// 0x0000007E System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_CustomLicenseRequestBuilder(System.Func`3<UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[],System.Byte[]>)
extern void MLMediaPlayer_set_CustomLicenseRequestBuilder_mF38D75427FACFE4DAB9D531F9DC9873226AD2BAC ();
// 0x0000007F System.Func`3<UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[],System.Byte[]> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_CustomLicenseResponseParser()
extern void MLMediaPlayer_get_CustomLicenseResponseParser_m52486AE705622C348DFC5FB6ECB826A5BDFF0344 ();
// 0x00000080 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_CustomLicenseResponseParser(System.Func`3<UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[],System.Byte[]>)
extern void MLMediaPlayer_set_CustomLicenseResponseParser_mD9097E0967EECDB418D8B8F78A09CB4C9552D104 ();
// 0x00000081 System.Action`1<System.Int32> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnPlay()
extern void MLMediaPlayer_get_OnPlay_m4EA2A2B6247E31F97871D9A3EFFE042EDC262E8E ();
// 0x00000082 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnPlay(System.Action`1<System.Int32>)
extern void MLMediaPlayer_set_OnPlay_m8F6F3956305842A5917882B3E542DD1BE2209141 ();
// 0x00000083 System.Action UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnPause()
extern void MLMediaPlayer_get_OnPause_mA564F433A72F9BF8B3DE7EB9F19F9CB006BF0287 ();
// 0x00000084 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnPause(System.Action)
extern void MLMediaPlayer_set_OnPause_m8DB0A0E85EB34CAE2559102675AE32C01255D38B ();
// 0x00000085 System.Action UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnStop()
extern void MLMediaPlayer_get_OnStop_mA7E3816A71530D90985C3D5614F870CFB1078178 ();
// 0x00000086 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnStop(System.Action)
extern void MLMediaPlayer_set_OnStop_mB07B1055659222C528F023521DA17810E8D54DDF ();
// 0x00000087 System.Action`1<System.Single> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnSeekStarted()
extern void MLMediaPlayer_get_OnSeekStarted_m964EF61A83C93D89946725B19800B1E0DBAD32BE ();
// 0x00000088 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnSeekStarted(System.Action`1<System.Single>)
extern void MLMediaPlayer_set_OnSeekStarted_mB5A45458828BACF4157A15B2D7F17522C32688EA ();
// 0x00000089 System.Action`1<System.Single> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnSeekCompleted()
extern void MLMediaPlayer_get_OnSeekCompleted_m17B7C4B4921678E919996A67255D3C263FA06A3D ();
// 0x0000008A System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnSeekCompleted(System.Action`1<System.Single>)
extern void MLMediaPlayer_set_OnSeekCompleted_m4CBED0CAB33E0C6EAD213EF2D7C3D13AD93A215F ();
// 0x0000008B System.Action`1<UnityEngine.Rect> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnVideoSizeChanged()
extern void MLMediaPlayer_get_OnVideoSizeChanged_m86D3CFFECAD7E60DF9681B5479E591604A2E3BB3 ();
// 0x0000008C System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnVideoSizeChanged(System.Action`1<UnityEngine.Rect>)
extern void MLMediaPlayer_set_OnVideoSizeChanged_m827B0DD8E8AB9BFEDA5D542E14BD1823415F9F11 ();
// 0x0000008D System.Action UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnEnded()
extern void MLMediaPlayer_get_OnEnded_m39E3F72A04894804EC46799C40C1D3624E509113 ();
// 0x0000008E System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnEnded(System.Action)
extern void MLMediaPlayer_set_OnEnded_m84F885D398B08C227851249CCD78A1203252CC06 ();
// 0x0000008F System.Action`1<System.Single> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnBufferingUpdate()
extern void MLMediaPlayer_get_OnBufferingUpdate_m2883D7816290AA2D893EF02E6603AD6915080FF5 ();
// 0x00000090 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnBufferingUpdate(System.Action`1<System.Single>)
extern void MLMediaPlayer_set_OnBufferingUpdate_mD80BBA9861546C4A6DD6DD0FCD664F00DF39A809 ();
// 0x00000091 System.Action`1<System.Single> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnFrameSizeSetup()
extern void MLMediaPlayer_get_OnFrameSizeSetup_m91182B326BF2E3855E6195A39B793BD7556EBAD5 ();
// 0x00000092 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnFrameSizeSetup(System.Action`1<System.Single>)
extern void MLMediaPlayer_set_OnFrameSizeSetup_m0928ED5FA49EC292C43A3B5ACC1E99C29FF3E02F ();
// 0x00000093 System.Action UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnVideoPrepared()
extern void MLMediaPlayer_get_OnVideoPrepared_m0A4AC4D4BBB417AFFDF04721F3E55D43212BD3ED ();
// 0x00000094 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnVideoPrepared(System.Action)
extern void MLMediaPlayer_set_OnVideoPrepared_m845AEA904230B37A2ACCF98FCD9FFEA50934AF5E ();
// 0x00000095 System.Action`2<UnityEngine.XR.MagicLeap.MLResultCode,System.String> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnMediaError()
extern void MLMediaPlayer_get_OnMediaError_mC7DC37C70218EB0669AEC7E8B4874F9EBF7C845F ();
// 0x00000096 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnMediaError(System.Action`2<UnityEngine.XR.MagicLeap.MLResultCode,System.String>)
extern void MLMediaPlayer_set_OnMediaError_m5BEF86A930014427A3A89E1A3E936BD5793FFA31 ();
// 0x00000097 System.Action`1<System.Collections.Generic.Dictionary`2<System.Int64,UnityEngine.XR.MagicLeap.TrackData>> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnSubtitleTracksFound()
extern void MLMediaPlayer_get_OnSubtitleTracksFound_m67645315B0C3BFF387F4CC080DA9460896F05A0A ();
// 0x00000098 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnSubtitleTracksFound(System.Action`1<System.Collections.Generic.Dictionary`2<System.Int64,UnityEngine.XR.MagicLeap.TrackData>>)
extern void MLMediaPlayer_set_OnSubtitleTracksFound_mC28A57B86ACE2E5CAA2AEA37BF34F6F8C7CCDCAA ();
// 0x00000099 System.Action`1<UnityEngine.XR.MagicLeap.MLCea608CaptionSegment> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnSubtitleDataFound()
extern void MLMediaPlayer_get_OnSubtitleDataFound_m3A5966DA4466016437C7D904AA9329F79DB09CD6 ();
// 0x0000009A System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnSubtitleDataFound(System.Action`1<UnityEngine.XR.MagicLeap.MLCea608CaptionSegment>)
extern void MLMediaPlayer_set_OnSubtitleDataFound_m7B2FA970B6C1FF12F84B841FF96C1AEB0BA3C69B ();
// 0x0000009B System.Action`3<System.String,System.Int64,System.Int64> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnTimedTextDataFound()
extern void MLMediaPlayer_get_OnTimedTextDataFound_m52B34227E9FFAFC92FDA5A63A865CB6733725DE3 ();
// 0x0000009C System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnTimedTextDataFound(System.Action`3<System.String,System.Int64,System.Int64>)
extern void MLMediaPlayer_set_OnTimedTextDataFound_m4C6E6955A6EA672F5BD90565C456951D291FD1ED ();
// 0x0000009D System.Action`2<UnityEngine.XR.MagicLeap.MLMediaPlayerInfo,System.Int32> UnityEngine.XR.MagicLeap.MLMediaPlayer::get_OnInfo()
extern void MLMediaPlayer_get_OnInfo_mF04C429ECE612BC54CE2732443B4BF4D643C9E98 ();
// 0x0000009E System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_OnInfo(System.Action`2<UnityEngine.XR.MagicLeap.MLMediaPlayerInfo,System.Int32>)
extern void MLMediaPlayer_set_OnInfo_mB96B782C9AC761926F11CE6C2DCCA3F745058C30 ();
// 0x0000009F System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayer::get_MediaPlayerID()
extern void MLMediaPlayer_get_MediaPlayerID_m20FF77CCBCCFE2B87672FB1885F8DBB059F91489 ();
// 0x000000A0 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_MediaPlayerID(System.Int32)
extern void MLMediaPlayer_set_MediaPlayerID_mBB0B23241525918F1877EE3EF286375DF0043F4A ();
// 0x000000A1 System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayer::get_IsLooping()
extern void MLMediaPlayer_get_IsLooping_mFCD232D5DE0F441EDE9269616F28B521318D5644 ();
// 0x000000A2 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_IsLooping(System.Boolean)
extern void MLMediaPlayer_set_IsLooping_mD1FFBE781641336B5105FAF813700AEEAC89ECBC ();
// 0x000000A3 System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayer::get_IsPlaying()
extern void MLMediaPlayer_get_IsPlaying_mDA95056F699C8AA90233A38D58047674F7F68853 ();
// 0x000000A4 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_IsPlaying(System.Boolean)
extern void MLMediaPlayer_set_IsPlaying_m2EB51675D0A82E700E03E7F1386BBAC710456841 ();
// 0x000000A5 System.Single UnityEngine.XR.MagicLeap.MLMediaPlayer::get_AnimationPosition()
extern void MLMediaPlayer_get_AnimationPosition_m25E110102177773CB3708B33A0E7D730F63B4714 ();
// 0x000000A6 System.UInt64 UnityEngine.XR.MagicLeap.MLMediaPlayer::get_FrameDropThresholdMs()
extern void MLMediaPlayer_get_FrameDropThresholdMs_mED0EB5B13CA43AB0D515CB185E21C6A7D83817C3 ();
// 0x000000A7 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::set_FrameDropThresholdMs(System.UInt64)
extern void MLMediaPlayer_set_FrameDropThresholdMs_mD2A69DACDA37AB40717BA0109601D41AE17E71E3 ();
// 0x000000A8 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayer::PrepareVideo()
extern void MLMediaPlayer_PrepareVideo_m68CFB9EEB0AEF31D40276E108A7991EC043E60D1 ();
// 0x000000A9 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayer::Seek(System.Int32)
extern void MLMediaPlayer_Seek_m3925E26732188582021D4B12779BB5E1D539DAF8 ();
// 0x000000AA UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayer::Seek(System.Single)
extern void MLMediaPlayer_Seek_m3D9158A58E1527B7517CB1B9AF728F14028357E0 ();
// 0x000000AB UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayer::SetVolume(System.Single)
extern void MLMediaPlayer_SetVolume_mA0A1CAEA4B7536C6FF01B12DDDB70FC6A839B6D6 ();
// 0x000000AC System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayer::GetElapsedTimeMs()
extern void MLMediaPlayer_GetElapsedTimeMs_mBBBAA13F45EACC3B7EC7589349C72359C53CE159 ();
// 0x000000AD System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayer::GetDurationMs()
extern void MLMediaPlayer_GetDurationMs_m844ADE51380FE5E4590E7DDF91BACFE349CDE939 ();
// 0x000000AE UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayer::Play()
extern void MLMediaPlayer_Play_m40D8952C147C1A5EE5E762660EDA9110A199FA06 ();
// 0x000000AF UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayer::Pause()
extern void MLMediaPlayer_Pause_m0110465E7D1AD225A42C39AEE640AB716BD867C3 ();
// 0x000000B0 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayer::Stop()
extern void MLMediaPlayer_Stop_m06387BE210BF27A78C4A878557E681D313060B52 ();
// 0x000000B1 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayer::SelectSubtitleTrack(System.UInt32)
extern void MLMediaPlayer_SelectSubtitleTrack_m5D52533302AF1E5D9095C44F8FBC3DB33A1E57A2 ();
// 0x000000B2 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayer::UnselectSubtitleTrack(System.UInt32)
extern void MLMediaPlayer_UnselectSubtitleTrack_m7DAC7E4DEC021BB5E1D42AF1773BF54B8932CC8A ();
// 0x000000B3 System.Collections.Generic.Dictionary`2<System.Int64,UnityEngine.XR.MagicLeap.TrackData> UnityEngine.XR.MagicLeap.MLMediaPlayer::GetAllTrackInfo()
extern void MLMediaPlayer_GetAllTrackInfo_m7EA896C0387134FF2E443FBEFFDAC948EA145114 ();
// 0x000000B4 System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayer::RequestActivationKeyRequest(System.Byte[],System.Action`3<UnityEngine.XR.MagicLeap.MLResult,System.Byte[],System.String>)
extern void MLMediaPlayer_RequestActivationKeyRequest_m9C23F96076918647453891453B12E3B22C3FDF7A ();
// 0x000000B5 UnityEngine.Rect UnityEngine.XR.MagicLeap.MLMediaPlayer::GetResolution()
extern void MLMediaPlayer_GetResolution_mF9BEEB81576343F1A2BCAA1E8175D5C137EDE1E8 ();
// 0x000000B6 System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayer::GetVideoBitrate()
extern void MLMediaPlayer_GetVideoBitrate_mD0FBDACB8BE79E1E8D9CE3146B93CAFCA94AE41B ();
// 0x000000B7 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::Awake()
extern void MLMediaPlayer_Awake_mE95847E8419FC7BDCC97DB2CFA6073951E8CAEF6 ();
// 0x000000B8 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::Quit()
extern void MLMediaPlayer_Quit_mE3CE8B47DA56C5557AB3D2E7E92CFAC925D5A88E ();
// 0x000000B9 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::CreateAndApplyBackdropTexture(System.Int32,System.Int32)
extern void MLMediaPlayer_CreateAndApplyBackdropTexture_mD3B564E6B3C73532315E9836F759ACF965A294CF ();
// 0x000000BA System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::OnDestroy()
extern void MLMediaPlayer_OnDestroy_m6DC55DEB99E5F2FC9B99A187D89596B394FD3371 ();
// 0x000000BB System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::OnApplicationPause(System.Boolean)
extern void MLMediaPlayer_OnApplicationPause_m707CBABAAD343672394EB3ACB6F500EB9E7EA960 ();
// 0x000000BC System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::CacheSubtitleTracks(System.Object,System.Object)
extern void MLMediaPlayer_CacheSubtitleTracks_m843FA092C12988A8417CA607F1300638087F745E ();
// 0x000000BD System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::VideoEnded(System.Object)
extern void MLMediaPlayer_VideoEnded_mCC4C021E7F72A7B8C392048524982346AD7AEF07 ();
// 0x000000BE System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::HandleVideoError(System.Object,System.Object,System.Object)
extern void MLMediaPlayer_HandleVideoError_mA58065E4D3A2B4AFC47984069E4760ABDE117C44 ();
// 0x000000BF System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::HandleVideoInfo(System.Object,System.Object,System.Object)
extern void MLMediaPlayer_HandleVideoInfo_mF456E5C7B83FA8545F977F6DDD36BA1715F6ED4D ();
// 0x000000C0 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::HandleSeekCompleted(System.Object)
extern void MLMediaPlayer_HandleSeekCompleted_mBB806E4D19DED03ABA1BC8B78943B57E96D48F0A ();
// 0x000000C1 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::HandleVideoSizeChanged(System.Object,System.Object)
extern void MLMediaPlayer_HandleVideoSizeChanged_mF68182F93234B5E33D2BDDA62AF8D02A6D0D1ABF ();
// 0x000000C2 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::HandleSubtitleTracksFound(System.Object,System.Object)
extern void MLMediaPlayer_HandleSubtitleTracksFound_mFF6FBA5BBDE322E00B262E7845F44762B24CBDC5 ();
// 0x000000C3 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::HandleSubtitleDataReceived(System.Object,System.Object)
extern void MLMediaPlayer_HandleSubtitleDataReceived_mC1641CCAFABD1D19F5EB071EA7000723D37E38CD ();
// 0x000000C4 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::HandleTimedTextDataReceived(System.Object,System.Object,System.Object,System.Object)
extern void MLMediaPlayer_HandleTimedTextDataReceived_m879F6F18754DE5E4D0B3D5965AC9009EAA27C56B ();
// 0x000000C5 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::UpdateBufferingUI(System.Object,System.Object)
extern void MLMediaPlayer_UpdateBufferingUI_m99BF961770C96EFF282B7D24E089B233EE159263 ();
// 0x000000C6 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayer::StartPreparedVideo(System.Object)
extern void MLMediaPlayer_StartPreparedVideo_m330890F24F492C8F25EA457F20BD51232BCC523D ();
// 0x000000C7 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::.ctor()
extern void MLMediaPlayer__ctor_mF69AB295E10CD552F9BF63EAD85A81B05EF235AE ();
// 0x000000C8 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayer::.cctor()
extern void MLMediaPlayer__cctor_m60749253B7383D3433594F915C91934C0A39495C ();
// 0x000000C9 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::Initialize(System.Int32,System.Action`1<System.Object>,System.Func`2<System.Object,UnityEngine.XR.MagicLeap.MLResult>,System.Action`1<System.Object>)
extern void MLMediaPlayerEditor_Initialize_m07EF4C4948B995DE5A924D5C4C9EF2122C622E97 ();
// 0x000000CA UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::CreateStreamingMediaPlayer(UnityEngine.GameObject,System.String,System.Int32)
extern void MLMediaPlayerEditor_CreateStreamingMediaPlayer_mE78FAFA985E19FB6A959B3BCE1BED95062032CED ();
// 0x000000CB System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::OnDestroy()
extern void MLMediaPlayerEditor_OnDestroy_m21751650C3E246C78E6AED56EBAA9EFAB7A82242 ();
// 0x000000CC System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::CreateTexture(UnityEngine.Renderer,System.Int32)
extern void MLMediaPlayerEditor_CreateTexture_mE344A5BA6887994D0D726A748B44A9AB5BAE5C33 ();
// 0x000000CD UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::Play(System.Int32)
extern void MLMediaPlayerEditor_Play_m180715ACB55293A0AF17115ABE9F3C3234C09CCD ();
// 0x000000CE UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::PauseVideo(System.Int32)
extern void MLMediaPlayerEditor_PauseVideo_m6CCEF1FF07BD941DD8B5839C33E7B4D7CA99BCB5 ();
// 0x000000CF UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::Seek(System.Int32,System.Int32)
extern void MLMediaPlayerEditor_Seek_mA7DB2FC33CD2FEF40AF4E47A2DEC41AA4EAD13E5 ();
// 0x000000D0 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::SetVolume(System.Single,System.Int32)
extern void MLMediaPlayerEditor_SetVolume_m51320ADA3E990ABB5B88DECE1559AC0A4B038CB1 ();
// 0x000000D1 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::Stop(System.Int32)
extern void MLMediaPlayerEditor_Stop_mA4C3C43C65F7885F6A263D2B6736620B8EA5973B ();
// 0x000000D2 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::Resume(System.Int32)
extern void MLMediaPlayerEditor_Resume_m565F1876D71F919209D28336D23A81D00B6B38B6 ();
// 0x000000D3 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::SetLooping(System.Boolean,System.Int32)
extern void MLMediaPlayerEditor_SetLooping_m18B9FE959F8496CED7F59A9C091BA4C2937CB5DD ();
// 0x000000D4 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::Cleanup(System.Int32)
extern void MLMediaPlayerEditor_Cleanup_m1859D6F89BB370E5D5C790A1A6AB667837BE8D4A ();
// 0x000000D5 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::SelectSubtitleTrack(System.Int32,System.UInt32)
extern void MLMediaPlayerEditor_SelectSubtitleTrack_m2227A4CBCF4572DF39AA9BAF4D534E03CB669786 ();
// 0x000000D6 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::UnselectSubtitleTrack(System.Int32,System.UInt32)
extern void MLMediaPlayerEditor_UnselectSubtitleTrack_mD72C89074B4773FA8D442E28CA2F6414A348CE1A ();
// 0x000000D7 System.Collections.Generic.Dictionary`2<System.Int64,UnityEngine.XR.MagicLeap.TrackData> UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::GetAllTrackInfo(System.Int32)
extern void MLMediaPlayerEditor_GetAllTrackInfo_m4C2568D85D64A0A68CE274E1605792C2991363F9 ();
// 0x000000D8 System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::RequestActivationKeyRequest(System.Byte[],System.Action`3<UnityEngine.XR.MagicLeap.MLResult,System.Byte[],System.String>)
extern void MLMediaPlayerEditor_RequestActivationKeyRequest_mD8BD195AB23CAFAB7161839334268E8071CC1975 ();
// 0x000000D9 UnityEngine.Rect UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::GetResolution(System.Int32)
extern void MLMediaPlayerEditor_GetResolution_m78EFF0A6271B0C84888CB405CAFD7D69743129F8 ();
// 0x000000DA System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::GetVideoBitrate(System.Int32)
extern void MLMediaPlayerEditor_GetVideoBitrate_m4B232477451DCF1695EF3E3B317F76D6B3DA8FFB ();
// 0x000000DB System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::GetDurationMilliseconds(System.Int32)
extern void MLMediaPlayerEditor_GetDurationMilliseconds_m9D8C1BB6DCC81413002161B655B6A089D72C9BA5 ();
// 0x000000DC System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::GetPositionMilliseconds(System.Int32)
extern void MLMediaPlayerEditor_GetPositionMilliseconds_m43C1ADF423C6BC3FD0A2C6E1032EA41350B5DEF9 ();
// 0x000000DD System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::GetWidth(System.Int32)
extern void MLMediaPlayerEditor_GetWidth_m2C5CC293678AD98F41113C953EE05253DD22F4F3 ();
// 0x000000DE System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::GetHeight(System.Int32)
extern void MLMediaPlayerEditor_GetHeight_m7D4B54244320E7351AC8511A8835B6974A818325 ();
// 0x000000DF System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::SetLicenseServer(System.String)
extern void MLMediaPlayerEditor_SetLicenseServer_m062DEC0A4A60C9C754BF934AFD0C5DDF8FCB8EF8 ();
// 0x000000E0 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::SetCustomLicenseHeaderData(System.Collections.Generic.Dictionary`2<System.String,System.String>)
extern void MLMediaPlayerEditor_SetCustomLicenseHeaderData_m9AFFE47C9F5062402E81FA517057EB3219F9C038 ();
// 0x000000E1 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::SetCustomLicenseMessageData(System.Collections.Generic.Dictionary`2<System.String,System.String>)
extern void MLMediaPlayerEditor_SetCustomLicenseMessageData_mB7014B21F6F7F7893971A2B637E070B40461EFA1 ();
// 0x000000E2 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::SetCustomLicenseRequestBuilder(System.Func`3<UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[],System.Byte[]>)
extern void MLMediaPlayerEditor_SetCustomLicenseRequestBuilder_mF85832517E65263EA715613BBCA71AF9793DE94A ();
// 0x000000E3 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::SetCustomLicenseResponseParser(System.Func`3<UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[],System.Byte[]>)
extern void MLMediaPlayerEditor_SetCustomLicenseResponseParser_m2042A1C98C7188F2E81B0B9877D753A36BEE1A65 ();
// 0x000000E4 System.UInt64 UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::GetFrameDropThresholdMs(System.Int32)
extern void MLMediaPlayerEditor_GetFrameDropThresholdMs_m08D3B87A2FB26100682C7789294CA26C9335305D ();
// 0x000000E5 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::SetFrameDropThresholdMs(System.Int32,System.UInt64)
extern void MLMediaPlayerEditor_SetFrameDropThresholdMs_m9EBD679263CC52F335AD4E146633EC5EE1096E35 ();
// 0x000000E6 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::HandlePrepareCompleted(UnityEngine.Video.VideoPlayer)
extern void MLMediaPlayerEditor_HandlePrepareCompleted_mF0692747A575C98C53D51DCB3DC69A3DB82D49B7 ();
// 0x000000E7 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::HandleVideoEnded(UnityEngine.Video.VideoPlayer)
extern void MLMediaPlayerEditor_HandleVideoEnded_mE376EE97BE2548A6FD4D347589DEAB10F280433B ();
// 0x000000E8 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::HandleSeekCompleted(UnityEngine.Video.VideoPlayer)
extern void MLMediaPlayerEditor_HandleSeekCompleted_mDDF8EAA1E6FB6FF5CB9FF3E0C8F82934FBB1CD96 ();
// 0x000000E9 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerEditor::.ctor()
extern void MLMediaPlayerEditor__ctor_m9E72060AD1D6D6C5CDA4309B6F285677C666E90D ();
// 0x000000EA System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::QueueCallback(System.String,System.Int32,System.Collections.Generic.List`1<System.Object>)
extern void MLMediaPlayerLumin_QueueCallback_m08FEB840C6FBFE8A40AFA3AE926139FBB8536B5B ();
// 0x000000EB System.Collections.IEnumerator UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::BeginVideo()
extern void MLMediaPlayerLumin_BeginVideo_mD08828E4D4952C1381F50E411FBD638025AA9A0E ();
// 0x000000EC System.Collections.IEnumerator UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::ProvisionDeviceForDRM(System.Int32)
extern void MLMediaPlayerLumin_ProvisionDeviceForDRM_m6AF31F74F41377CCB15834DDEEE5CB8651E46E25 ();
// 0x000000ED System.Collections.IEnumerator UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::GetKeysAndPrepareDRM(System.Int32,UnityEngine.XR.MagicLeap.MLMediaDRMTrack)
extern void MLMediaPlayerLumin_GetKeysAndPrepareDRM_mCAFC3B6C24432C9752CC834A920F855057C7C4FB ();
// 0x000000EE System.Collections.IEnumerator UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PerformDRMHandshakeForDRMTrack(System.Int32,UnityEngine.XR.MagicLeap.MLMediaDRMTrack)
extern void MLMediaPlayerLumin_PerformDRMHandshakeForDRMTrack_m35170DA337D0A33947319222704F9EA7380A1029 ();
// 0x000000EF System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::AddCustomLicenseHeaders(UnityEngine.Networking.UnityWebRequest)
extern void MLMediaPlayerLumin_AddCustomLicenseHeaders_mE5F2F6B47556870ACF392E797ECD03DE5C03A765 ();
// 0x000000F0 System.Byte[] UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::ProcessLicenseResponse(UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[])
extern void MLMediaPlayerLumin_ProcessLicenseResponse_m98511C0ED96DEFFDA207D0AF880CC178EC5A7281 ();
// 0x000000F1 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::Initialize(System.Int32,System.Action`1<System.Object>,System.Func`2<System.Object,UnityEngine.XR.MagicLeap.MLResult>,System.Action`2<System.Object,System.Object>,System.Action`3<System.Object,System.Object,System.Object>,System.Action`3<System.Object,System.Object,System.Object>,System.Action`1<System.Object>,System.Action`2<System.Object,System.Object>,System.Action`2<System.Object,System.Object>,System.Action`2<System.Object,System.Object>,System.Action`4<System.Object,System.Object,System.Object,System.Object>)
extern void MLMediaPlayerLumin_Initialize_mEAC5AD217D4A08948D21B7576B0D8C39C47ACB11 ();
// 0x000000F2 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::Update()
extern void MLMediaPlayerLumin_Update_m36D3050F634B0D16CD99673EA4E70A3C2258053A ();
// 0x000000F3 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerReadyHandler(System.Int32)
extern void MLMediaPlayerLumin_PlayerReadyHandler_m08402407BBEA563DC4ACE7EA567976F0A48851A8 ();
// 0x000000F4 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerCompleteHandler(System.Int32)
extern void MLMediaPlayerLumin_PlayerCompleteHandler_mECEFB5CF5266B05754052B9EBABB7D783DEB9706 ();
// 0x000000F5 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerBufferingUpdateHandler(System.Int32,System.Int32)
extern void MLMediaPlayerLumin_PlayerBufferingUpdateHandler_m70E834A6D0048C3921514AC2DFD0D93D79ABF97C ();
// 0x000000F6 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerErrorHandler(System.Int32,System.IntPtr,System.Int32)
extern void MLMediaPlayerLumin_PlayerErrorHandler_mCDC0FFF7009DAB8147E0BA34E15D85230E4BDDFE ();
// 0x000000F7 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerInfoHandler(System.Int32,System.Int32,System.Int32)
extern void MLMediaPlayerLumin_PlayerInfoHandler_mAE9A95B9C5A09D37E46D708E6D0313A23057BBA1 ();
// 0x000000F8 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerVideoSizeChangedHandler(System.Int32,System.Int32,System.Int32)
extern void MLMediaPlayerLumin_PlayerVideoSizeChangedHandler_m6444791D1773DE1ACEE49D3BFF350F61FD6DE383 ();
// 0x000000F9 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerTrackDRMInfoHandler(System.UInt32,System.Int32)
extern void MLMediaPlayerLumin_PlayerTrackDRMInfoHandler_mBDAAB37287AE7DAB9FE33E0C90A7702A22F15495 ();
// 0x000000FA System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerSeekCompletedHandler(System.Int32)
extern void MLMediaPlayerLumin_PlayerSeekCompletedHandler_m3BB59DF6FB9AEDFC1E9856AA1325E670125DC0DE ();
// 0x000000FB System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerSubtitleTracksHandler(System.Int32,UnityEngine.XR.MagicLeap.SubtitleInfo)
extern void MLMediaPlayerLumin_PlayerSubtitleTracksHandler_m717BFF1D80FFA1816165031B5791F48C472CEB01 ();
// 0x000000FC System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerTracksHandler(System.Int32,System.IntPtr,System.Int32)
extern void MLMediaPlayerLumin_PlayerTracksHandler_m7388835E15F27BC46B187CAF7C3E50487E41A9C0 ();
// 0x000000FD System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerSubtitleDataHandler(System.Int32,UnityEngine.XR.MagicLeap.MLCea608CaptionSegmentInternal&)
extern void MLMediaPlayerLumin_PlayerSubtitleDataHandler_m8A0E7CFE3EBCA6EA54B5C6FC73AD9BA929426972 ();
// 0x000000FE System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PlayerTimedTextInfoHandler(System.Int32,System.IntPtr,System.Int64,System.Int64)
extern void MLMediaPlayerLumin_PlayerTimedTextInfoHandler_mBDC916A77C650A21A996FD886875D842202A010C ();
// 0x000000FF UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::CreateStreamingMediaPlayer(UnityEngine.GameObject,System.String,System.Int32)
extern void MLMediaPlayerLumin_CreateStreamingMediaPlayer_m3603DC6F98212AF9C2174C89248EEA79D19B6125 ();
// 0x00000100 System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::CreateTexture(UnityEngine.Renderer,System.Int32)
extern void MLMediaPlayerLumin_CreateTexture_m28A74CF4455D10872BF6566AB5B13328D45A2D38 ();
// 0x00000101 System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::CreateTexture(UnityEngine.Renderer,System.Int32,System.Int32,System.Int32)
extern void MLMediaPlayerLumin_CreateTexture_m5EC24DC791443CCF930AB49748022DA61539EAAC ();
// 0x00000102 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::Play(System.Int32)
extern void MLMediaPlayerLumin_Play_m8456C53C2C45B8923C8D9BF1DCF982689DFC1F1A ();
// 0x00000103 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::PauseVideo(System.Int32)
extern void MLMediaPlayerLumin_PauseVideo_m0FCA4F5F6D3DE5B9078B92DB44B5BC43FC5BE762 ();
// 0x00000104 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::Seek(System.Int32,System.Int32)
extern void MLMediaPlayerLumin_Seek_mF1FB8E94F5A0E2FC12BD5ACDBFD26D843667E53D ();
// 0x00000105 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::SetVolume(System.Single,System.Int32)
extern void MLMediaPlayerLumin_SetVolume_m561FE1BD6B3D08A146F74F1AE69C71A30F862998 ();
// 0x00000106 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::Stop(System.Int32)
extern void MLMediaPlayerLumin_Stop_mE330EE1C64150ACA1642D5CDB8D83495F3C81D8C ();
// 0x00000107 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::Resume(System.Int32)
extern void MLMediaPlayerLumin_Resume_mC637BE7E92B3731B0FDC4C1A59C46FC91BE4CB5A ();
// 0x00000108 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::SetLooping(System.Boolean,System.Int32)
extern void MLMediaPlayerLumin_SetLooping_m37C358FDD56E4D9D44D36F6DE17D1E19C7148C0F ();
// 0x00000109 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::Cleanup(System.Int32)
extern void MLMediaPlayerLumin_Cleanup_m8ED76EC15C15E6E42E06A15744D8780CF7B3F7C4 ();
// 0x0000010A System.Collections.IEnumerator UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::RequestActivationKeyRequestCoroutine(System.Byte[],System.Action`3<UnityEngine.XR.MagicLeap.MLResult,System.Byte[],System.String>)
extern void MLMediaPlayerLumin_RequestActivationKeyRequestCoroutine_m1322A75D8C500F12DA4F62E700B2232DBF005FB2 ();
// 0x0000010B System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::RequestActivationKeyRequest(System.Byte[],System.Action`3<UnityEngine.XR.MagicLeap.MLResult,System.Byte[],System.String>)
extern void MLMediaPlayerLumin_RequestActivationKeyRequest_m970F57DB585357CE3B89963CE9AFB4DC5C51CE37 ();
// 0x0000010C System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::GetDurationMilliseconds(System.Int32)
extern void MLMediaPlayerLumin_GetDurationMilliseconds_m28A56DDDB7D11687584F373C871BEB91DB927DF8 ();
// 0x0000010D System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::GetPositionMilliseconds(System.Int32)
extern void MLMediaPlayerLumin_GetPositionMilliseconds_mD3CD5F374B1E4D89E9F079C02775208B1274F0FB ();
// 0x0000010E System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::GetWidth(System.Int32)
extern void MLMediaPlayerLumin_GetWidth_m36ECEE52E1BA25E73A0F56C032CC688C1A6BBDD1 ();
// 0x0000010F System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::GetHeight(System.Int32)
extern void MLMediaPlayerLumin_GetHeight_m63D7AA32E4FF789F1A2B1F5CC120D5573D586566 ();
// 0x00000110 UnityEngine.Rect UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::GetResolution(System.Int32)
extern void MLMediaPlayerLumin_GetResolution_m2B872E05007FD224DC845028598CDC4859F5C519 ();
// 0x00000111 System.Int32 UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::GetVideoBitrate(System.Int32)
extern void MLMediaPlayerLumin_GetVideoBitrate_m1916F162111BBE212E02BE0AC07BF34A8BF9A683 ();
// 0x00000112 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::SetLicenseServer(System.String)
extern void MLMediaPlayerLumin_SetLicenseServer_m37E29AA4EAE99AE514D7A948D9BABAAEDDB256F4 ();
// 0x00000113 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::SetCustomLicenseHeaderData(System.Collections.Generic.Dictionary`2<System.String,System.String>)
extern void MLMediaPlayerLumin_SetCustomLicenseHeaderData_m1B9BE370429F9231D72AD643952B4C368B1B5AE7 ();
// 0x00000114 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::SetCustomLicenseMessageData(System.Collections.Generic.Dictionary`2<System.String,System.String>)
extern void MLMediaPlayerLumin_SetCustomLicenseMessageData_m3727735A9F1379A15FEDC97F594D53C87882B543 ();
// 0x00000115 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::SetCustomLicenseRequestBuilder(System.Func`3<UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[],System.Byte[]>)
extern void MLMediaPlayerLumin_SetCustomLicenseRequestBuilder_m0F0983EFC5BB29769EFFCFE9DD228CE0E0ED5888 ();
// 0x00000116 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::SetCustomLicenseResponseParser(System.Func`3<UnityEngine.XR.MagicLeap.MLMediaDRMTrack,System.Byte[],System.Byte[]>)
extern void MLMediaPlayerLumin_SetCustomLicenseResponseParser_m60C9C87D285F2CC1CF8F51330E31AC2BC219F33C ();
// 0x00000117 System.UInt64 UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::GetFrameDropThresholdMs(System.Int32)
extern void MLMediaPlayerLumin_GetFrameDropThresholdMs_mB220D81D353343C60BE9FA8861CA32F0EFD5BC4E ();
// 0x00000118 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::SetFrameDropThresholdMs(System.Int32,System.UInt64)
extern void MLMediaPlayerLumin_SetFrameDropThresholdMs_mA541FA4B9202EC4536AA5E1D9F1EF47A146BEED5 ();
// 0x00000119 UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::SelectSubtitleTrack(System.Int32,System.UInt32)
extern void MLMediaPlayerLumin_SelectSubtitleTrack_m6A92C8F3C43B3E217556494DFFA95350D19105AD ();
// 0x0000011A UnityEngine.XR.MagicLeap.MLResult UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::UnselectSubtitleTrack(System.Int32,System.UInt32)
extern void MLMediaPlayerLumin_UnselectSubtitleTrack_m270FC001BDEA8B468E07B5AADC2BF89DE39BB500 ();
// 0x0000011B System.Collections.Generic.Dictionary`2<System.Int64,UnityEngine.XR.MagicLeap.TrackData> UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::GetAllTrackInfo(System.Int32)
extern void MLMediaPlayerLumin_GetAllTrackInfo_mD57F7C0065CE89805B9C1A36E6AB45D9AC36BE84 ();
// 0x0000011C System.IntPtr UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::GetRenderCallback()
extern void MLMediaPlayerLumin_GetRenderCallback_m57887000345642ED97F744CDF04F84A66A3904EC ();
// 0x0000011D System.Collections.IEnumerator UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::CallPluginAtEndOfFrames()
extern void MLMediaPlayerLumin_CallPluginAtEndOfFrames_mF8841335891EF0A1603B0CB3CE57C637D7E8A030 ();
// 0x0000011E System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::.ctor()
extern void MLMediaPlayerLumin__ctor_m4CD03A71FE905BEDBC693FF57FBF9F2C1302B4C7 ();
// 0x0000011F System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin::.cctor()
extern void MLMediaPlayerLumin__cctor_m6997EBF1508528E6AD2CBCF24D8D381A2A67C01F ();
// 0x00000120 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_QueuedCallback::.ctor(System.String,System.Collections.Generic.List`1<System.Object>)
extern void QueuedCallback__ctor_m10BA7374CDB45FDC9785BE0178251D12C50A8E11 ();
// 0x00000121 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<BeginVideo>d__43::.ctor(System.Int32)
extern void U3CBeginVideoU3Ed__43__ctor_mB500CFC20021EB781A49960BF0BA5DD55002C819 ();
// 0x00000122 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<BeginVideo>d__43::System.IDisposable.Dispose()
extern void U3CBeginVideoU3Ed__43_System_IDisposable_Dispose_m26007DA6DADFE06004DC1769C3E983F5C6925A05 ();
// 0x00000123 System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<BeginVideo>d__43::MoveNext()
extern void U3CBeginVideoU3Ed__43_MoveNext_m938F947578F61FFFDA27BC9AC8AA6508EDDE8AE4 ();
// 0x00000124 System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<BeginVideo>d__43::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
extern void U3CBeginVideoU3Ed__43_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_m40798618F1539686188F4432221D7594D9B7C34B ();
// 0x00000125 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<BeginVideo>d__43::System.Collections.IEnumerator.Reset()
extern void U3CBeginVideoU3Ed__43_System_Collections_IEnumerator_Reset_mA0BF37889C3AC75B28C22084B45917F33768F739 ();
// 0x00000126 System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<BeginVideo>d__43::System.Collections.IEnumerator.get_Current()
extern void U3CBeginVideoU3Ed__43_System_Collections_IEnumerator_get_Current_m549ADB82C003E3B6CCDA5F15D626AE54998BBF92 ();
// 0x00000127 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<ProvisionDeviceForDRM>d__44::.ctor(System.Int32)
extern void U3CProvisionDeviceForDRMU3Ed__44__ctor_m9ACB482A692ED1B88ECF17B16C41A987271D8742 ();
// 0x00000128 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<ProvisionDeviceForDRM>d__44::System.IDisposable.Dispose()
extern void U3CProvisionDeviceForDRMU3Ed__44_System_IDisposable_Dispose_m13EAEC6E014635909270EB89CBC4787D2B72565D ();
// 0x00000129 System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<ProvisionDeviceForDRM>d__44::MoveNext()
extern void U3CProvisionDeviceForDRMU3Ed__44_MoveNext_m379FD2F5699E55588257BE71FBC539575A6C6934 ();
// 0x0000012A System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<ProvisionDeviceForDRM>d__44::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
extern void U3CProvisionDeviceForDRMU3Ed__44_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_mDE86DEDBE598B6220F3F4A90FA5E98DED3BFE3A2 ();
// 0x0000012B System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<ProvisionDeviceForDRM>d__44::System.Collections.IEnumerator.Reset()
extern void U3CProvisionDeviceForDRMU3Ed__44_System_Collections_IEnumerator_Reset_m0187DE295DF362B1457BC1DCAFF002267DC305D2 ();
// 0x0000012C System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<ProvisionDeviceForDRM>d__44::System.Collections.IEnumerator.get_Current()
extern void U3CProvisionDeviceForDRMU3Ed__44_System_Collections_IEnumerator_get_Current_m44299FD635714474DFC37B465811BEFEE8CB2A5C ();
// 0x0000012D System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<GetKeysAndPrepareDRM>d__45::.ctor(System.Int32)
extern void U3CGetKeysAndPrepareDRMU3Ed__45__ctor_m47FF33A5BAFA419ED1F1C533AB004FFE1459A8D4 ();
// 0x0000012E System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<GetKeysAndPrepareDRM>d__45::System.IDisposable.Dispose()
extern void U3CGetKeysAndPrepareDRMU3Ed__45_System_IDisposable_Dispose_m9603D3B7197C9386736F54D4F51800D63612CBE7 ();
// 0x0000012F System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<GetKeysAndPrepareDRM>d__45::MoveNext()
extern void U3CGetKeysAndPrepareDRMU3Ed__45_MoveNext_m463DDAC763C5FACBB732E5AF9031D8A2FE3B565C ();
// 0x00000130 System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<GetKeysAndPrepareDRM>d__45::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
extern void U3CGetKeysAndPrepareDRMU3Ed__45_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_m4E6179E08C0CD3792E4A65398922890295E0C0B9 ();
// 0x00000131 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<GetKeysAndPrepareDRM>d__45::System.Collections.IEnumerator.Reset()
extern void U3CGetKeysAndPrepareDRMU3Ed__45_System_Collections_IEnumerator_Reset_mF7F29EEF2AC814688B7B0E9ACB9272AAF850C2D4 ();
// 0x00000132 System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<GetKeysAndPrepareDRM>d__45::System.Collections.IEnumerator.get_Current()
extern void U3CGetKeysAndPrepareDRMU3Ed__45_System_Collections_IEnumerator_get_Current_m44575FE72402095E7218864B1E796802E08CE485 ();
// 0x00000133 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<PerformDRMHandshakeForDRMTrack>d__46::.ctor(System.Int32)
extern void U3CPerformDRMHandshakeForDRMTrackU3Ed__46__ctor_m8E8F1D02295687F9D31027DD9D557CB9D7F1EA4E ();
// 0x00000134 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<PerformDRMHandshakeForDRMTrack>d__46::System.IDisposable.Dispose()
extern void U3CPerformDRMHandshakeForDRMTrackU3Ed__46_System_IDisposable_Dispose_m9C31323005E0D68AE7A5256F49EBA61193FE2E27 ();
// 0x00000135 System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<PerformDRMHandshakeForDRMTrack>d__46::MoveNext()
extern void U3CPerformDRMHandshakeForDRMTrackU3Ed__46_MoveNext_m3E32955871BCB182115AB169CF633501DA7C6F32 ();
// 0x00000136 System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<PerformDRMHandshakeForDRMTrack>d__46::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
extern void U3CPerformDRMHandshakeForDRMTrackU3Ed__46_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_m5ABFC856885C54373E49C3DF501D0BEBC2E1D384 ();
// 0x00000137 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<PerformDRMHandshakeForDRMTrack>d__46::System.Collections.IEnumerator.Reset()
extern void U3CPerformDRMHandshakeForDRMTrackU3Ed__46_System_Collections_IEnumerator_Reset_mF36493A9A9A88027F30C8687F35A396F7CF2F59C ();
// 0x00000138 System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<PerformDRMHandshakeForDRMTrack>d__46::System.Collections.IEnumerator.get_Current()
extern void U3CPerformDRMHandshakeForDRMTrackU3Ed__46_System_Collections_IEnumerator_get_Current_mFC16AE82D6651021C36C5933876952257FDD84AE ();
// 0x00000139 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<RequestActivationKeyRequestCoroutine>d__74::.ctor(System.Int32)
extern void U3CRequestActivationKeyRequestCoroutineU3Ed__74__ctor_m72A255E0A6D0E4A27ACDBD7429C8D96C6FEB1CA6 ();
// 0x0000013A System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<RequestActivationKeyRequestCoroutine>d__74::System.IDisposable.Dispose()
extern void U3CRequestActivationKeyRequestCoroutineU3Ed__74_System_IDisposable_Dispose_mD6B6E8EB4CD9D58E9FFA9319799403218BFF7022 ();
// 0x0000013B System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<RequestActivationKeyRequestCoroutine>d__74::MoveNext()
extern void U3CRequestActivationKeyRequestCoroutineU3Ed__74_MoveNext_m5DB7891169272855CD39562450E0247D9FE24A21 ();
// 0x0000013C System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<RequestActivationKeyRequestCoroutine>d__74::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
extern void U3CRequestActivationKeyRequestCoroutineU3Ed__74_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_mD5C7818182CDD380228D8BB445E28FDD101A09EA ();
// 0x0000013D System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<RequestActivationKeyRequestCoroutine>d__74::System.Collections.IEnumerator.Reset()
extern void U3CRequestActivationKeyRequestCoroutineU3Ed__74_System_Collections_IEnumerator_Reset_m87A8857155933AB9FAAC814B7670CCA0514F30D1 ();
// 0x0000013E System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<RequestActivationKeyRequestCoroutine>d__74::System.Collections.IEnumerator.get_Current()
extern void U3CRequestActivationKeyRequestCoroutineU3Ed__74_System_Collections_IEnumerator_get_Current_m36E4C53245C2AAC681DC931EF91EEBC00DE473EE ();
// 0x0000013F System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<CallPluginAtEndOfFrames>d__93::.ctor(System.Int32)
extern void U3CCallPluginAtEndOfFramesU3Ed__93__ctor_mE6A4012F3EDCC8A2BC299B01AF600125A5C82F8B ();
// 0x00000140 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<CallPluginAtEndOfFrames>d__93::System.IDisposable.Dispose()
extern void U3CCallPluginAtEndOfFramesU3Ed__93_System_IDisposable_Dispose_mEE8B137A17E4EC74CD64128252800D45D9C0ED19 ();
// 0x00000141 System.Boolean UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<CallPluginAtEndOfFrames>d__93::MoveNext()
extern void U3CCallPluginAtEndOfFramesU3Ed__93_MoveNext_m9288DD08AD331D044D2E59658C51A64D303598B9 ();
// 0x00000142 System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<CallPluginAtEndOfFrames>d__93::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
extern void U3CCallPluginAtEndOfFramesU3Ed__93_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_mB1D1A729BC8CB1D7928DE7CB22C70CB9FD46186F ();
// 0x00000143 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<CallPluginAtEndOfFrames>d__93::System.Collections.IEnumerator.Reset()
extern void U3CCallPluginAtEndOfFramesU3Ed__93_System_Collections_IEnumerator_Reset_m32062A9C158A833E32279EA31C9639F6B6B46AF0 ();
// 0x00000144 System.Object UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<CallPluginAtEndOfFrames>d__93::System.Collections.IEnumerator.get_Current()
extern void U3CCallPluginAtEndOfFramesU3Ed__93_System_Collections_IEnumerator_get_Current_m70E837482BD383D770672B68227E49E81C527CEE ();
// 0x00000145 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<>c::.cctor()
extern void U3CU3Ec__cctor_m45CAE390DAD56DFD4F9AE0DFD558B00F65FB9FA5 ();
// 0x00000146 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<>c::.ctor()
extern void U3CU3Ec__ctor_mE2BEFF54BCACF90C011CE2B15B21667B08F26DBB ();
// 0x00000147 System.Void UnityEngine.XR.MagicLeap.MLMediaPlayerLumin_<>c::<.ctor>b__94_0(UnityEngine.XR.MagicLeap.MLResult,System.Byte[],System.String)
extern void U3CU3Ec_U3C_ctorU3Eb__94_0_m8ADB7EBF35373226B23822BC40E6A1B055C7B4EA ();
// 0x00000148 System.Void UnityEngine.XR.MagicLeap.MLCea608CaptionStyleColor::.ctor()
extern void MLCea608CaptionStyleColor__ctor_m207DCBFAB7BA9FA4F3292EB3CBB91B8949D1546E ();
// 0x00000149 System.Void UnityEngine.XR.MagicLeap.MLCea608CaptionPAC::.ctor()
extern void MLCea608CaptionPAC__ctor_m7AE2A114B0447A67F2A427DFBAC3A386814A478D ();
// 0x0000014A System.Void UnityEngine.XR.MagicLeap.MLCea608CaptionLine::.ctor()
extern void MLCea608CaptionLine__ctor_m8D91796947A831864E9B3AB86B30862E8654ABE7 ();
// 0x0000014B System.Void UnityEngine.XR.MagicLeap.MLPluginLog::Debug(System.Object)
extern void MLPluginLog_Debug_mC2E826251F54D2529F9193C3A5F29528CB29AFAD ();
// 0x0000014C System.Void UnityEngine.XR.MagicLeap.MLPluginLog::DebugFormat(System.String,System.Object[])
extern void MLPluginLog_DebugFormat_mC5B610AA5A9839B6FF4594A8F08B7F878EB1662E ();
// 0x0000014D System.Void UnityEngine.XR.MagicLeap.MLPluginLog::Warning(System.Object)
extern void MLPluginLog_Warning_mBA530C92C785F7A8EC0F43794B4B71988051C158 ();
// 0x0000014E System.Void UnityEngine.XR.MagicLeap.MLPluginLog::WarningFormat(System.String,System.Object[])
extern void MLPluginLog_WarningFormat_m832B9A8AC0582F91512D8268AEC7C8252BC24189 ();
// 0x0000014F System.Void UnityEngine.XR.MagicLeap.MLPluginLog::Error(System.Object)
extern void MLPluginLog_Error_mA71E3348B0707C3B4739C2F4D139434AF8A6EB7D ();
// 0x00000150 System.Void UnityEngine.XR.MagicLeap.MLPluginLog::ErrorFormat(System.String,System.Object[])
extern void MLPluginLog_ErrorFormat_mD2E61A8F8B0C12462D086CE437D4FB35C422319E ();
// 0x00000151 System.UInt32 <PrivateImplementationDetails>::ComputeStringHash(System.String)
extern void U3CPrivateImplementationDetailsU3E_ComputeStringHash_mACCA0AC108CA6C5A74FCD15C2D7A2BFA63B581D7 ();
static Il2CppMethodPointer s_methodPointers[337] = 
{
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	MediaPlayerNativeBindings_GetRenderCallback_mC918271C533676217DDF54EAD94F61EDE197E2A2,
	MediaPlayerNativeBindings_GetRenderCleanupCallback_mC32A08F859C642169357F7C8640BD9A3D4CE9859,
	MediaPlayerNativeBindings_SetTextureFromUnity_mCBC0A349878CF031C3B54DD430F2F5663E21AF88,
	MediaPlayerNativeBindings_SetupStreamingMediaPlayer_mDC866F61512933F5C8D5E217872E30DCBFF14E79,
	MediaPlayerNativeBindings_OpenDRMSession_mFD4E2D02E8B68AD931397094A0FABB057CB8D31F,
	MediaPlayerNativeBindings_CloseDRMSession_m66FD45CF0C2EBCBBD4F2C0E3B9740F676A248464,
	MediaPlayerNativeBindings_SetKeyRequestCustomData_mC236F7A2FD824F18048B61B660C366E2DF740F1D,
	MediaPlayerNativeBindings_GetProvisionRequest_m6EDEBD4F432D42C5FE23C6B638F76E4829B72951,
	MediaPlayerNativeBindings_ProvideProvisionResponse_m0EA1405AA3CE84447B9EF2925643DE9F0E6936E3,
	MediaPlayerNativeBindings_GetActivationProvisionRequest_m7504509FAA1E08109CC1916104EE8C11EA7BE7F5,
	MediaPlayerNativeBindings_ProvideActivationProvisionResponse_mC801CDC4D63DE648CD823CEBFB4CA4E8F9BFB2D2,
	MediaPlayerNativeBindings_GetActivationKeyRequest_mB034D4E68BDDD0CD68709BC21677A44457BF4AE8,
	MediaPlayerNativeBindings_GetKeyRequest_m1DC68B6965256F35A41FCDECA3CA91613C8F1E41,
	MediaPlayerNativeBindings_ProvideKeyResponse_m2B819CC6DC69FD531F49B551DA911ED0BD16005B,
	MediaPlayerNativeBindings_PrepareDRM_m82AFD6A1C0DF3028357D0387998255CD840CC008,
	MediaPlayerNativeBindings_Play_m036F47AEB96EB3E22750EFCDEBFD8E1A84550838,
	MediaPlayerNativeBindings_PauseVideo_m3EFF5CCE24928960E21B6A41E4EEDA2FEBD96540,
	MediaPlayerNativeBindings_Seek_m82D41B649F13A883A7070E2421CCE66236E95D05,
	MediaPlayerNativeBindings_Cleanup_m6B161A0372892A6AF774696DAA62107FEC86F32D,
	MediaPlayerNativeBindings_SetVolume_mB84467B9BDD256F28A161AEBDCC4B41261D5EFDE,
	MediaPlayerNativeBindings_Stop_m2EDA0944ACFC2574930FDF9E70599C43D2F7DE0F,
	MediaPlayerNativeBindings_Resume_m8EBFCDC43AFA0CF7D0AA1C9B7F276A30360E13D3,
	MediaPlayerNativeBindings_GetDurationMilliseconds_m7D038B8EA60AA811EB080778F176D0235EBB8D55,
	MediaPlayerNativeBindings_GetPositionMilliseconds_m62E34E426EE1B0A993843BED012FBED9F1D61B20,
	MediaPlayerNativeBindings_GetWidth_m03BF536B09785849A6F87F7EB86F5998997B2683,
	MediaPlayerNativeBindings_GetHeight_m9141E73E8A6BB6C55B174CD12A06484E4D7ED3E4,
	MediaPlayerNativeBindings_SetLooping_m5052795E3CE69D235BA356B1E0020E9FCC8DEAC8,
	MediaPlayerNativeBindings_GetFrameDropThresholdMs_m09C1FF36343A50C098004EB2DB6A250E0D99B5D7,
	MediaPlayerNativeBindings_SetFrameDropThresholdMs_mCE4D75F25B36416F98B9F2B33331BDF19F943096,
	MediaPlayerNativeBindings_GetVideoBitrate_m06332D28FC93DACE55B9C0A1FD0F36D80F30CCAA,
	MediaPlayerNativeBindings_GetTrackData_mE045BF65E0B4B4C03F7FE85A6B37AC4F4DD3E514,
	MediaPlayerNativeBindings_GetSubtitleTracks_m8C4F3050506DD365E317587B14611DD383B53D77,
	MediaPlayerNativeBindings_SelectSubtitleTrack_m3A89885770007F89EEBECD5BF3803B304FE52240,
	MediaPlayerNativeBindings_UnselectSubtitleTrack_m3556DC8BDF084FF38F0AC8B54758D1003484A5EB,
	MediaPlayerNativeBindings__ctor_m119041C7D50664069E7B697614F5C4F05F0DB325,
	PlayerReadyCallback__ctor_m459619B1D557A228A4475A109ABC045DC98F5AF2,
	PlayerReadyCallback_Invoke_mB6EC20EEFEC46FE297F69530E95A4598B4627409,
	PlayerReadyCallback_BeginInvoke_mBAC986DF572F99C52EEA22E2AF4852EAD938BF65,
	PlayerReadyCallback_EndInvoke_m78CBECD6AA5F2270BE70E9A9D406077E42CA572C,
	PlayerCompleteCallback__ctor_m6542958FC8009BFB7646E65D276313C60879B270,
	PlayerCompleteCallback_Invoke_m42FA0946F70DF3BF0C485952735A72F47C381151,
	PlayerCompleteCallback_BeginInvoke_m17582FC9EB7ABA15DA849999274F32060B46FB1A,
	PlayerCompleteCallback_EndInvoke_mAC875DB7A8073379E12CD2775D4E3AF58C5C0E16,
	PlayerBufferingCallback__ctor_mC3367D0F209CECA05DA81F603DB9897D1E88251F,
	PlayerBufferingCallback_Invoke_mECE347C13C26570554C6FA92D4D1BC819E75EE4D,
	PlayerBufferingCallback_BeginInvoke_m33A13C27799226CE6457CC871F342ED41CD9DD21,
	PlayerBufferingCallback_EndInvoke_m60F6812F6448EA533E596998D115A5B69EF260B6,
	PlayerErrorCallback__ctor_mF24AB55968D2B31E2256B086B72045BBE06487A3,
	PlayerErrorCallback_Invoke_m70F3619C8523C9A78B94256F5EE108728556EE51,
	PlayerErrorCallback_BeginInvoke_m2083FEA0BDFAE2B94399C8C0EAF90A2A53F1A905,
	PlayerErrorCallback_EndInvoke_m7031BF6B4DE50B8A09B7660DBE01B60C4DF60F2D,
	PlayerInfoCallback__ctor_m10C18134F648DCCE83132019D0DDE34E71C84FE8,
	PlayerInfoCallback_Invoke_mE76A31AA416067DA8207956AB2067516B101D10C,
	PlayerInfoCallback_BeginInvoke_mBE8CEAA6B11C838C4F0639D25EC076EFD734514F,
	PlayerInfoCallback_EndInvoke_m248574F9404EC5908029FFEAD90FABF551464132,
	PlayerVideoSizeChangedCallback__ctor_m066C5446637425B769600DC781705194656A54E8,
	PlayerVideoSizeChangedCallback_Invoke_m84AE578A67E06D9FD5EDEC22E19A986B105AB862,
	PlayerVideoSizeChangedCallback_BeginInvoke_m1BEB5C7CAA35DED901608329DC88974C47D7E3A3,
	PlayerVideoSizeChangedCallback_EndInvoke_m2D6A15954A1F7F6AD340BB3E6BDFFD728D5BD5F2,
	PlayerTrackDRMInfoCallback__ctor_m39B3EC9E2BA2B14837F10938AEDA755A1FF52716,
	PlayerTrackDRMInfoCallback_Invoke_m652E011746771DE19AF2FF3A3E95F9284D6A2B46,
	PlayerTrackDRMInfoCallback_BeginInvoke_m22CF5B2BC9238573DF3BC716AD0749085AD9D8B5,
	PlayerTrackDRMInfoCallback_EndInvoke_m8B432621EE3884135FAB14279239E8906D35ED72,
	PlayerSeekCompletedCallback__ctor_m217AE793BC39B95611645505304F21B0DB85535E,
	PlayerSeekCompletedCallback_Invoke_m80B412BFF5F6261A9ABCC849616B62E3512022EF,
	PlayerSeekCompletedCallback_BeginInvoke_m3B559EE4B5E4AA853E9E941A1A9766FFE0F0E4C2,
	PlayerSeekCompletedCallback_EndInvoke_mE09312DF428427AA896BC0CBDEA0D0BA07D6E739,
	PlayerSubtitleTracksCallback__ctor_mC571D28B80AAE33F0C2B15D9FD9B7AAFC38B289F,
	PlayerSubtitleTracksCallback_Invoke_m84F45288862BFF03CF9B7E299486D9D3FF2E125C,
	PlayerSubtitleTracksCallback_BeginInvoke_m7DCB406A2EC9D7238B545A7EBD3CE6BBCF4C66F9,
	PlayerSubtitleTracksCallback_EndInvoke_mC87531A8480AD66F91491519B1B049CCD0F413D9,
	PlayerTracksCallback__ctor_mE056B6B7581FBF6C4D8CC4CFBDC9E7A34E32FE37,
	PlayerTracksCallback_Invoke_m6EA8E3C44E68AFAB7FF6FC804C2BB1B4F71D5D39,
	PlayerTracksCallback_BeginInvoke_m58835DC3B2917D34DDBEAAB0967585DAB2524E7E,
	PlayerTracksCallback_EndInvoke_m239B8666D6DE4925A92C0806EAD0457B93B5A32A,
	PlayerSubtitleDataCallback__ctor_m60A04B83836BE2A50A3221F428472C22C48DAF18,
	PlayerSubtitleDataCallback_Invoke_mB0ACC46EEBD6EDF1F45124EAB04AEE5D81B68E8F,
	PlayerSubtitleDataCallback_BeginInvoke_m092FF929A0444DEE1D17B080EEACF6C69F1B12BD,
	PlayerSubtitleDataCallback_EndInvoke_m345068E37B7AA5071A5D9E46977998BD3412EA25,
	PlayerTimedTextInfoCallback__ctor_m9E27EAAB0720CBFFB30C6A763E818EB8BC20F3AE,
	PlayerTimedTextInfoCallback_Invoke_m563B9EBF05A9B1769DEB1700D9FE0D6258C15868,
	PlayerTimedTextInfoCallback_BeginInvoke_m846698EDDE7B2C6B16F2A502331FACD9CACBD2BB,
	PlayerTimedTextInfoCallback_EndInvoke_m2BEA933D46CA2C7DB07787996D90233D2FE68C9C,
	MLMediaPlayer_TryApplyStereoMode_mD8BE7E97A6CA1609C235ED3F8789F82D62D4FEDF,
	MLMediaPlayer_ApplyVideoRenderMaterial_mFB6EA50CEBBFBF8DED1FFED7CC62908CAFB4D5DE,
	MLMediaPlayer_get_VideoRenderMaterial_m6DE1AB32E0346B9B4EEEC6D092BDB23B3AFFE290,
	MLMediaPlayer_set_VideoRenderMaterial_m559BE47832A378E601B3C6C6921156E20A25FD15,
	MLMediaPlayer_get_StereoMode_m91665472BEED336310A92D0EC753E0089D23A2FE,
	MLMediaPlayer_set_StereoMode_mB18B9849668F74BEB84E7B6063A8E81010302515,
	MLMediaPlayer_get_VideoSource_m17AD68FCA8A6CD5076EDE6F75CEC58B8D542F85A,
	MLMediaPlayer_set_VideoSource_m964049C6DE88D5044D7989D1E544E7EB9196BE71,
	MLMediaPlayer_get_LicenseServer_m30D6773E0985AA1B103EEAFA5DD47D0B168C5184,
	MLMediaPlayer_set_LicenseServer_mAC146A56ADDE2A214FDF95390626C6DC3E2B6966,
	MLMediaPlayer_get_CustomLicenseHeaderData_m625F9408305DC24C21B4AAAA14B82A7FF3E22D35,
	MLMediaPlayer_set_CustomLicenseHeaderData_mA46EA7A3BAAE49D626B4F902B4AC2F50E277AEA9,
	MLMediaPlayer_get_CustomLicenseMessageData_m89BF9501F6CAFA11E04FBA200E47CB192F585409,
	MLMediaPlayer_set_CustomLicenseMessageData_m450555E93910DD936BFBA899DB2187D14DB53B48,
	MLMediaPlayer_get_CustomLicenseRequestBuilder_m556BCE2B73FDAA6693A8A8896B3F4E319E839D49,
	MLMediaPlayer_set_CustomLicenseRequestBuilder_mF38D75427FACFE4DAB9D531F9DC9873226AD2BAC,
	MLMediaPlayer_get_CustomLicenseResponseParser_m52486AE705622C348DFC5FB6ECB826A5BDFF0344,
	MLMediaPlayer_set_CustomLicenseResponseParser_mD9097E0967EECDB418D8B8F78A09CB4C9552D104,
	MLMediaPlayer_get_OnPlay_m4EA2A2B6247E31F97871D9A3EFFE042EDC262E8E,
	MLMediaPlayer_set_OnPlay_m8F6F3956305842A5917882B3E542DD1BE2209141,
	MLMediaPlayer_get_OnPause_mA564F433A72F9BF8B3DE7EB9F19F9CB006BF0287,
	MLMediaPlayer_set_OnPause_m8DB0A0E85EB34CAE2559102675AE32C01255D38B,
	MLMediaPlayer_get_OnStop_mA7E3816A71530D90985C3D5614F870CFB1078178,
	MLMediaPlayer_set_OnStop_mB07B1055659222C528F023521DA17810E8D54DDF,
	MLMediaPlayer_get_OnSeekStarted_m964EF61A83C93D89946725B19800B1E0DBAD32BE,
	MLMediaPlayer_set_OnSeekStarted_mB5A45458828BACF4157A15B2D7F17522C32688EA,
	MLMediaPlayer_get_OnSeekCompleted_m17B7C4B4921678E919996A67255D3C263FA06A3D,
	MLMediaPlayer_set_OnSeekCompleted_m4CBED0CAB33E0C6EAD213EF2D7C3D13AD93A215F,
	MLMediaPlayer_get_OnVideoSizeChanged_m86D3CFFECAD7E60DF9681B5479E591604A2E3BB3,
	MLMediaPlayer_set_OnVideoSizeChanged_m827B0DD8E8AB9BFEDA5D542E14BD1823415F9F11,
	MLMediaPlayer_get_OnEnded_m39E3F72A04894804EC46799C40C1D3624E509113,
	MLMediaPlayer_set_OnEnded_m84F885D398B08C227851249CCD78A1203252CC06,
	MLMediaPlayer_get_OnBufferingUpdate_m2883D7816290AA2D893EF02E6603AD6915080FF5,
	MLMediaPlayer_set_OnBufferingUpdate_mD80BBA9861546C4A6DD6DD0FCD664F00DF39A809,
	MLMediaPlayer_get_OnFrameSizeSetup_m91182B326BF2E3855E6195A39B793BD7556EBAD5,
	MLMediaPlayer_set_OnFrameSizeSetup_m0928ED5FA49EC292C43A3B5ACC1E99C29FF3E02F,
	MLMediaPlayer_get_OnVideoPrepared_m0A4AC4D4BBB417AFFDF04721F3E55D43212BD3ED,
	MLMediaPlayer_set_OnVideoPrepared_m845AEA904230B37A2ACCF98FCD9FFEA50934AF5E,
	MLMediaPlayer_get_OnMediaError_mC7DC37C70218EB0669AEC7E8B4874F9EBF7C845F,
	MLMediaPlayer_set_OnMediaError_m5BEF86A930014427A3A89E1A3E936BD5793FFA31,
	MLMediaPlayer_get_OnSubtitleTracksFound_m67645315B0C3BFF387F4CC080DA9460896F05A0A,
	MLMediaPlayer_set_OnSubtitleTracksFound_mC28A57B86ACE2E5CAA2AEA37BF34F6F8C7CCDCAA,
	MLMediaPlayer_get_OnSubtitleDataFound_m3A5966DA4466016437C7D904AA9329F79DB09CD6,
	MLMediaPlayer_set_OnSubtitleDataFound_m7B2FA970B6C1FF12F84B841FF96C1AEB0BA3C69B,
	MLMediaPlayer_get_OnTimedTextDataFound_m52B34227E9FFAFC92FDA5A63A865CB6733725DE3,
	MLMediaPlayer_set_OnTimedTextDataFound_m4C6E6955A6EA672F5BD90565C456951D291FD1ED,
	MLMediaPlayer_get_OnInfo_mF04C429ECE612BC54CE2732443B4BF4D643C9E98,
	MLMediaPlayer_set_OnInfo_mB96B782C9AC761926F11CE6C2DCCA3F745058C30,
	MLMediaPlayer_get_MediaPlayerID_m20FF77CCBCCFE2B87672FB1885F8DBB059F91489,
	MLMediaPlayer_set_MediaPlayerID_mBB0B23241525918F1877EE3EF286375DF0043F4A,
	MLMediaPlayer_get_IsLooping_mFCD232D5DE0F441EDE9269616F28B521318D5644,
	MLMediaPlayer_set_IsLooping_mD1FFBE781641336B5105FAF813700AEEAC89ECBC,
	MLMediaPlayer_get_IsPlaying_mDA95056F699C8AA90233A38D58047674F7F68853,
	MLMediaPlayer_set_IsPlaying_m2EB51675D0A82E700E03E7F1386BBAC710456841,
	MLMediaPlayer_get_AnimationPosition_m25E110102177773CB3708B33A0E7D730F63B4714,
	MLMediaPlayer_get_FrameDropThresholdMs_mED0EB5B13CA43AB0D515CB185E21C6A7D83817C3,
	MLMediaPlayer_set_FrameDropThresholdMs_mD2A69DACDA37AB40717BA0109601D41AE17E71E3,
	MLMediaPlayer_PrepareVideo_m68CFB9EEB0AEF31D40276E108A7991EC043E60D1,
	MLMediaPlayer_Seek_m3925E26732188582021D4B12779BB5E1D539DAF8,
	MLMediaPlayer_Seek_m3D9158A58E1527B7517CB1B9AF728F14028357E0,
	MLMediaPlayer_SetVolume_mA0A1CAEA4B7536C6FF01B12DDDB70FC6A839B6D6,
	MLMediaPlayer_GetElapsedTimeMs_mBBBAA13F45EACC3B7EC7589349C72359C53CE159,
	MLMediaPlayer_GetDurationMs_m844ADE51380FE5E4590E7DDF91BACFE349CDE939,
	MLMediaPlayer_Play_m40D8952C147C1A5EE5E762660EDA9110A199FA06,
	MLMediaPlayer_Pause_m0110465E7D1AD225A42C39AEE640AB716BD867C3,
	MLMediaPlayer_Stop_m06387BE210BF27A78C4A878557E681D313060B52,
	MLMediaPlayer_SelectSubtitleTrack_m5D52533302AF1E5D9095C44F8FBC3DB33A1E57A2,
	MLMediaPlayer_UnselectSubtitleTrack_m7DAC7E4DEC021BB5E1D42AF1773BF54B8932CC8A,
	MLMediaPlayer_GetAllTrackInfo_m7EA896C0387134FF2E443FBEFFDAC948EA145114,
	MLMediaPlayer_RequestActivationKeyRequest_m9C23F96076918647453891453B12E3B22C3FDF7A,
	MLMediaPlayer_GetResolution_mF9BEEB81576343F1A2BCAA1E8175D5C137EDE1E8,
	MLMediaPlayer_GetVideoBitrate_mD0FBDACB8BE79E1E8D9CE3146B93CAFCA94AE41B,
	MLMediaPlayer_Awake_mE95847E8419FC7BDCC97DB2CFA6073951E8CAEF6,
	MLMediaPlayer_Quit_mE3CE8B47DA56C5557AB3D2E7E92CFAC925D5A88E,
	MLMediaPlayer_CreateAndApplyBackdropTexture_mD3B564E6B3C73532315E9836F759ACF965A294CF,
	MLMediaPlayer_OnDestroy_m6DC55DEB99E5F2FC9B99A187D89596B394FD3371,
	MLMediaPlayer_OnApplicationPause_m707CBABAAD343672394EB3ACB6F500EB9E7EA960,
	MLMediaPlayer_CacheSubtitleTracks_m843FA092C12988A8417CA607F1300638087F745E,
	MLMediaPlayer_VideoEnded_mCC4C021E7F72A7B8C392048524982346AD7AEF07,
	MLMediaPlayer_HandleVideoError_mA58065E4D3A2B4AFC47984069E4760ABDE117C44,
	MLMediaPlayer_HandleVideoInfo_mF456E5C7B83FA8545F977F6DDD36BA1715F6ED4D,
	MLMediaPlayer_HandleSeekCompleted_mBB806E4D19DED03ABA1BC8B78943B57E96D48F0A,
	MLMediaPlayer_HandleVideoSizeChanged_mF68182F93234B5E33D2BDDA62AF8D02A6D0D1ABF,
	MLMediaPlayer_HandleSubtitleTracksFound_mFF6FBA5BBDE322E00B262E7845F44762B24CBDC5,
	MLMediaPlayer_HandleSubtitleDataReceived_mC1641CCAFABD1D19F5EB071EA7000723D37E38CD,
	MLMediaPlayer_HandleTimedTextDataReceived_m879F6F18754DE5E4D0B3D5965AC9009EAA27C56B,
	MLMediaPlayer_UpdateBufferingUI_m99BF961770C96EFF282B7D24E089B233EE159263,
	MLMediaPlayer_StartPreparedVideo_m330890F24F492C8F25EA457F20BD51232BCC523D,
	MLMediaPlayer__ctor_mF69AB295E10CD552F9BF63EAD85A81B05EF235AE,
	MLMediaPlayer__cctor_m60749253B7383D3433594F915C91934C0A39495C,
	MLMediaPlayerEditor_Initialize_m07EF4C4948B995DE5A924D5C4C9EF2122C622E97,
	MLMediaPlayerEditor_CreateStreamingMediaPlayer_mE78FAFA985E19FB6A959B3BCE1BED95062032CED,
	MLMediaPlayerEditor_OnDestroy_m21751650C3E246C78E6AED56EBAA9EFAB7A82242,
	MLMediaPlayerEditor_CreateTexture_mE344A5BA6887994D0D726A748B44A9AB5BAE5C33,
	MLMediaPlayerEditor_Play_m180715ACB55293A0AF17115ABE9F3C3234C09CCD,
	MLMediaPlayerEditor_PauseVideo_m6CCEF1FF07BD941DD8B5839C33E7B4D7CA99BCB5,
	MLMediaPlayerEditor_Seek_mA7DB2FC33CD2FEF40AF4E47A2DEC41AA4EAD13E5,
	MLMediaPlayerEditor_SetVolume_m51320ADA3E990ABB5B88DECE1559AC0A4B038CB1,
	MLMediaPlayerEditor_Stop_mA4C3C43C65F7885F6A263D2B6736620B8EA5973B,
	MLMediaPlayerEditor_Resume_m565F1876D71F919209D28336D23A81D00B6B38B6,
	MLMediaPlayerEditor_SetLooping_m18B9FE959F8496CED7F59A9C091BA4C2937CB5DD,
	MLMediaPlayerEditor_Cleanup_m1859D6F89BB370E5D5C790A1A6AB667837BE8D4A,
	MLMediaPlayerEditor_SelectSubtitleTrack_m2227A4CBCF4572DF39AA9BAF4D534E03CB669786,
	MLMediaPlayerEditor_UnselectSubtitleTrack_mD72C89074B4773FA8D442E28CA2F6414A348CE1A,
	MLMediaPlayerEditor_GetAllTrackInfo_m4C2568D85D64A0A68CE274E1605792C2991363F9,
	MLMediaPlayerEditor_RequestActivationKeyRequest_mD8BD195AB23CAFAB7161839334268E8071CC1975,
	MLMediaPlayerEditor_GetResolution_m78EFF0A6271B0C84888CB405CAFD7D69743129F8,
	MLMediaPlayerEditor_GetVideoBitrate_m4B232477451DCF1695EF3E3B317F76D6B3DA8FFB,
	MLMediaPlayerEditor_GetDurationMilliseconds_m9D8C1BB6DCC81413002161B655B6A089D72C9BA5,
	MLMediaPlayerEditor_GetPositionMilliseconds_m43C1ADF423C6BC3FD0A2C6E1032EA41350B5DEF9,
	MLMediaPlayerEditor_GetWidth_m2C5CC293678AD98F41113C953EE05253DD22F4F3,
	MLMediaPlayerEditor_GetHeight_m7D4B54244320E7351AC8511A8835B6974A818325,
	MLMediaPlayerEditor_SetLicenseServer_m062DEC0A4A60C9C754BF934AFD0C5DDF8FCB8EF8,
	MLMediaPlayerEditor_SetCustomLicenseHeaderData_m9AFFE47C9F5062402E81FA517057EB3219F9C038,
	MLMediaPlayerEditor_SetCustomLicenseMessageData_mB7014B21F6F7F7893971A2B637E070B40461EFA1,
	MLMediaPlayerEditor_SetCustomLicenseRequestBuilder_mF85832517E65263EA715613BBCA71AF9793DE94A,
	MLMediaPlayerEditor_SetCustomLicenseResponseParser_m2042A1C98C7188F2E81B0B9877D753A36BEE1A65,
	MLMediaPlayerEditor_GetFrameDropThresholdMs_m08D3B87A2FB26100682C7789294CA26C9335305D,
	MLMediaPlayerEditor_SetFrameDropThresholdMs_m9EBD679263CC52F335AD4E146633EC5EE1096E35,
	MLMediaPlayerEditor_HandlePrepareCompleted_mF0692747A575C98C53D51DCB3DC69A3DB82D49B7,
	MLMediaPlayerEditor_HandleVideoEnded_mE376EE97BE2548A6FD4D347589DEAB10F280433B,
	MLMediaPlayerEditor_HandleSeekCompleted_mDDF8EAA1E6FB6FF5CB9FF3E0C8F82934FBB1CD96,
	MLMediaPlayerEditor__ctor_m9E72060AD1D6D6C5CDA4309B6F285677C666E90D,
	MLMediaPlayerLumin_QueueCallback_m08FEB840C6FBFE8A40AFA3AE926139FBB8536B5B,
	MLMediaPlayerLumin_BeginVideo_mD08828E4D4952C1381F50E411FBD638025AA9A0E,
	MLMediaPlayerLumin_ProvisionDeviceForDRM_m6AF31F74F41377CCB15834DDEEE5CB8651E46E25,
	MLMediaPlayerLumin_GetKeysAndPrepareDRM_mCAFC3B6C24432C9752CC834A920F855057C7C4FB,
	MLMediaPlayerLumin_PerformDRMHandshakeForDRMTrack_m35170DA337D0A33947319222704F9EA7380A1029,
	MLMediaPlayerLumin_AddCustomLicenseHeaders_mE5F2F6B47556870ACF392E797ECD03DE5C03A765,
	MLMediaPlayerLumin_ProcessLicenseResponse_m98511C0ED96DEFFDA207D0AF880CC178EC5A7281,
	MLMediaPlayerLumin_Initialize_mEAC5AD217D4A08948D21B7576B0D8C39C47ACB11,
	MLMediaPlayerLumin_Update_m36D3050F634B0D16CD99673EA4E70A3C2258053A,
	MLMediaPlayerLumin_PlayerReadyHandler_m08402407BBEA563DC4ACE7EA567976F0A48851A8,
	MLMediaPlayerLumin_PlayerCompleteHandler_mECEFB5CF5266B05754052B9EBABB7D783DEB9706,
	MLMediaPlayerLumin_PlayerBufferingUpdateHandler_m70E834A6D0048C3921514AC2DFD0D93D79ABF97C,
	MLMediaPlayerLumin_PlayerErrorHandler_mCDC0FFF7009DAB8147E0BA34E15D85230E4BDDFE,
	MLMediaPlayerLumin_PlayerInfoHandler_mAE9A95B9C5A09D37E46D708E6D0313A23057BBA1,
	MLMediaPlayerLumin_PlayerVideoSizeChangedHandler_m6444791D1773DE1ACEE49D3BFF350F61FD6DE383,
	MLMediaPlayerLumin_PlayerTrackDRMInfoHandler_mBDAAB37287AE7DAB9FE33E0C90A7702A22F15495,
	MLMediaPlayerLumin_PlayerSeekCompletedHandler_m3BB59DF6FB9AEDFC1E9856AA1325E670125DC0DE,
	MLMediaPlayerLumin_PlayerSubtitleTracksHandler_m717BFF1D80FFA1816165031B5791F48C472CEB01,
	MLMediaPlayerLumin_PlayerTracksHandler_m7388835E15F27BC46B187CAF7C3E50487E41A9C0,
	MLMediaPlayerLumin_PlayerSubtitleDataHandler_m8A0E7CFE3EBCA6EA54B5C6FC73AD9BA929426972,
	MLMediaPlayerLumin_PlayerTimedTextInfoHandler_mBDC916A77C650A21A996FD886875D842202A010C,
	MLMediaPlayerLumin_CreateStreamingMediaPlayer_m3603DC6F98212AF9C2174C89248EEA79D19B6125,
	MLMediaPlayerLumin_CreateTexture_m28A74CF4455D10872BF6566AB5B13328D45A2D38,
	MLMediaPlayerLumin_CreateTexture_m5EC24DC791443CCF930AB49748022DA61539EAAC,
	MLMediaPlayerLumin_Play_m8456C53C2C45B8923C8D9BF1DCF982689DFC1F1A,
	MLMediaPlayerLumin_PauseVideo_m0FCA4F5F6D3DE5B9078B92DB44B5BC43FC5BE762,
	MLMediaPlayerLumin_Seek_mF1FB8E94F5A0E2FC12BD5ACDBFD26D843667E53D,
	MLMediaPlayerLumin_SetVolume_m561FE1BD6B3D08A146F74F1AE69C71A30F862998,
	MLMediaPlayerLumin_Stop_mE330EE1C64150ACA1642D5CDB8D83495F3C81D8C,
	MLMediaPlayerLumin_Resume_mC637BE7E92B3731B0FDC4C1A59C46FC91BE4CB5A,
	MLMediaPlayerLumin_SetLooping_m37C358FDD56E4D9D44D36F6DE17D1E19C7148C0F,
	MLMediaPlayerLumin_Cleanup_m8ED76EC15C15E6E42E06A15744D8780CF7B3F7C4,
	MLMediaPlayerLumin_RequestActivationKeyRequestCoroutine_m1322A75D8C500F12DA4F62E700B2232DBF005FB2,
	MLMediaPlayerLumin_RequestActivationKeyRequest_m970F57DB585357CE3B89963CE9AFB4DC5C51CE37,
	MLMediaPlayerLumin_GetDurationMilliseconds_m28A56DDDB7D11687584F373C871BEB91DB927DF8,
	MLMediaPlayerLumin_GetPositionMilliseconds_mD3CD5F374B1E4D89E9F079C02775208B1274F0FB,
	MLMediaPlayerLumin_GetWidth_m36ECEE52E1BA25E73A0F56C032CC688C1A6BBDD1,
	MLMediaPlayerLumin_GetHeight_m63D7AA32E4FF789F1A2B1F5CC120D5573D586566,
	MLMediaPlayerLumin_GetResolution_m2B872E05007FD224DC845028598CDC4859F5C519,
	MLMediaPlayerLumin_GetVideoBitrate_m1916F162111BBE212E02BE0AC07BF34A8BF9A683,
	MLMediaPlayerLumin_SetLicenseServer_m37E29AA4EAE99AE514D7A948D9BABAAEDDB256F4,
	MLMediaPlayerLumin_SetCustomLicenseHeaderData_m1B9BE370429F9231D72AD643952B4C368B1B5AE7,
	MLMediaPlayerLumin_SetCustomLicenseMessageData_m3727735A9F1379A15FEDC97F594D53C87882B543,
	MLMediaPlayerLumin_SetCustomLicenseRequestBuilder_m0F0983EFC5BB29769EFFCFE9DD228CE0E0ED5888,
	MLMediaPlayerLumin_SetCustomLicenseResponseParser_m60C9C87D285F2CC1CF8F51330E31AC2BC219F33C,
	MLMediaPlayerLumin_GetFrameDropThresholdMs_mB220D81D353343C60BE9FA8861CA32F0EFD5BC4E,
	MLMediaPlayerLumin_SetFrameDropThresholdMs_mA541FA4B9202EC4536AA5E1D9F1EF47A146BEED5,
	MLMediaPlayerLumin_SelectSubtitleTrack_m6A92C8F3C43B3E217556494DFFA95350D19105AD,
	MLMediaPlayerLumin_UnselectSubtitleTrack_m270FC001BDEA8B468E07B5AADC2BF89DE39BB500,
	MLMediaPlayerLumin_GetAllTrackInfo_mD57F7C0065CE89805B9C1A36E6AB45D9AC36BE84,
	MLMediaPlayerLumin_GetRenderCallback_m57887000345642ED97F744CDF04F84A66A3904EC,
	MLMediaPlayerLumin_CallPluginAtEndOfFrames_mF8841335891EF0A1603B0CB3CE57C637D7E8A030,
	MLMediaPlayerLumin__ctor_m4CD03A71FE905BEDBC693FF57FBF9F2C1302B4C7,
	MLMediaPlayerLumin__cctor_m6997EBF1508528E6AD2CBCF24D8D381A2A67C01F,
	QueuedCallback__ctor_m10BA7374CDB45FDC9785BE0178251D12C50A8E11,
	U3CBeginVideoU3Ed__43__ctor_mB500CFC20021EB781A49960BF0BA5DD55002C819,
	U3CBeginVideoU3Ed__43_System_IDisposable_Dispose_m26007DA6DADFE06004DC1769C3E983F5C6925A05,
	U3CBeginVideoU3Ed__43_MoveNext_m938F947578F61FFFDA27BC9AC8AA6508EDDE8AE4,
	U3CBeginVideoU3Ed__43_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_m40798618F1539686188F4432221D7594D9B7C34B,
	U3CBeginVideoU3Ed__43_System_Collections_IEnumerator_Reset_mA0BF37889C3AC75B28C22084B45917F33768F739,
	U3CBeginVideoU3Ed__43_System_Collections_IEnumerator_get_Current_m549ADB82C003E3B6CCDA5F15D626AE54998BBF92,
	U3CProvisionDeviceForDRMU3Ed__44__ctor_m9ACB482A692ED1B88ECF17B16C41A987271D8742,
	U3CProvisionDeviceForDRMU3Ed__44_System_IDisposable_Dispose_m13EAEC6E014635909270EB89CBC4787D2B72565D,
	U3CProvisionDeviceForDRMU3Ed__44_MoveNext_m379FD2F5699E55588257BE71FBC539575A6C6934,
	U3CProvisionDeviceForDRMU3Ed__44_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_mDE86DEDBE598B6220F3F4A90FA5E98DED3BFE3A2,
	U3CProvisionDeviceForDRMU3Ed__44_System_Collections_IEnumerator_Reset_m0187DE295DF362B1457BC1DCAFF002267DC305D2,
	U3CProvisionDeviceForDRMU3Ed__44_System_Collections_IEnumerator_get_Current_m44299FD635714474DFC37B465811BEFEE8CB2A5C,
	U3CGetKeysAndPrepareDRMU3Ed__45__ctor_m47FF33A5BAFA419ED1F1C533AB004FFE1459A8D4,
	U3CGetKeysAndPrepareDRMU3Ed__45_System_IDisposable_Dispose_m9603D3B7197C9386736F54D4F51800D63612CBE7,
	U3CGetKeysAndPrepareDRMU3Ed__45_MoveNext_m463DDAC763C5FACBB732E5AF9031D8A2FE3B565C,
	U3CGetKeysAndPrepareDRMU3Ed__45_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_m4E6179E08C0CD3792E4A65398922890295E0C0B9,
	U3CGetKeysAndPrepareDRMU3Ed__45_System_Collections_IEnumerator_Reset_mF7F29EEF2AC814688B7B0E9ACB9272AAF850C2D4,
	U3CGetKeysAndPrepareDRMU3Ed__45_System_Collections_IEnumerator_get_Current_m44575FE72402095E7218864B1E796802E08CE485,
	U3CPerformDRMHandshakeForDRMTrackU3Ed__46__ctor_m8E8F1D02295687F9D31027DD9D557CB9D7F1EA4E,
	U3CPerformDRMHandshakeForDRMTrackU3Ed__46_System_IDisposable_Dispose_m9C31323005E0D68AE7A5256F49EBA61193FE2E27,
	U3CPerformDRMHandshakeForDRMTrackU3Ed__46_MoveNext_m3E32955871BCB182115AB169CF633501DA7C6F32,
	U3CPerformDRMHandshakeForDRMTrackU3Ed__46_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_m5ABFC856885C54373E49C3DF501D0BEBC2E1D384,
	U3CPerformDRMHandshakeForDRMTrackU3Ed__46_System_Collections_IEnumerator_Reset_mF36493A9A9A88027F30C8687F35A396F7CF2F59C,
	U3CPerformDRMHandshakeForDRMTrackU3Ed__46_System_Collections_IEnumerator_get_Current_mFC16AE82D6651021C36C5933876952257FDD84AE,
	U3CRequestActivationKeyRequestCoroutineU3Ed__74__ctor_m72A255E0A6D0E4A27ACDBD7429C8D96C6FEB1CA6,
	U3CRequestActivationKeyRequestCoroutineU3Ed__74_System_IDisposable_Dispose_mD6B6E8EB4CD9D58E9FFA9319799403218BFF7022,
	U3CRequestActivationKeyRequestCoroutineU3Ed__74_MoveNext_m5DB7891169272855CD39562450E0247D9FE24A21,
	U3CRequestActivationKeyRequestCoroutineU3Ed__74_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_mD5C7818182CDD380228D8BB445E28FDD101A09EA,
	U3CRequestActivationKeyRequestCoroutineU3Ed__74_System_Collections_IEnumerator_Reset_m87A8857155933AB9FAAC814B7670CCA0514F30D1,
	U3CRequestActivationKeyRequestCoroutineU3Ed__74_System_Collections_IEnumerator_get_Current_m36E4C53245C2AAC681DC931EF91EEBC00DE473EE,
	U3CCallPluginAtEndOfFramesU3Ed__93__ctor_mE6A4012F3EDCC8A2BC299B01AF600125A5C82F8B,
	U3CCallPluginAtEndOfFramesU3Ed__93_System_IDisposable_Dispose_mEE8B137A17E4EC74CD64128252800D45D9C0ED19,
	U3CCallPluginAtEndOfFramesU3Ed__93_MoveNext_m9288DD08AD331D044D2E59658C51A64D303598B9,
	U3CCallPluginAtEndOfFramesU3Ed__93_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_mB1D1A729BC8CB1D7928DE7CB22C70CB9FD46186F,
	U3CCallPluginAtEndOfFramesU3Ed__93_System_Collections_IEnumerator_Reset_m32062A9C158A833E32279EA31C9639F6B6B46AF0,
	U3CCallPluginAtEndOfFramesU3Ed__93_System_Collections_IEnumerator_get_Current_m70E837482BD383D770672B68227E49E81C527CEE,
	U3CU3Ec__cctor_m45CAE390DAD56DFD4F9AE0DFD558B00F65FB9FA5,
	U3CU3Ec__ctor_mE2BEFF54BCACF90C011CE2B15B21667B08F26DBB,
	U3CU3Ec_U3C_ctorU3Eb__94_0_m8ADB7EBF35373226B23822BC40E6A1B055C7B4EA,
	MLCea608CaptionStyleColor__ctor_m207DCBFAB7BA9FA4F3292EB3CBB91B8949D1546E,
	MLCea608CaptionPAC__ctor_m7AE2A114B0447A67F2A427DFBAC3A386814A478D,
	MLCea608CaptionLine__ctor_m8D91796947A831864E9B3AB86B30862E8654ABE7,
	MLPluginLog_Debug_mC2E826251F54D2529F9193C3A5F29528CB29AFAD,
	MLPluginLog_DebugFormat_mC5B610AA5A9839B6FF4594A8F08B7F878EB1662E,
	MLPluginLog_Warning_mBA530C92C785F7A8EC0F43794B4B71988051C158,
	MLPluginLog_WarningFormat_m832B9A8AC0582F91512D8268AEC7C8252BC24189,
	MLPluginLog_Error_mA71E3348B0707C3B4739C2F4D139434AF8A6EB7D,
	MLPluginLog_ErrorFormat_mD2E61A8F8B0C12462D086CE437D4FB35C422319E,
	U3CPrivateImplementationDetailsU3E_ComputeStringHash_mACCA0AC108CA6C5A74FCD15C2D7A2BFA63B581D7,
};
static const int32_t s_InvokerIndices[337] = 
{
	2067,
	435,
	1929,
	1929,
	2008,
	2068,
	1929,
	1929,
	2069,
	1929,
	2008,
	2008,
	34,
	115,
	37,
	37,
	37,
	37,
	2070,
	37,
	26,
	26,
	26,
	26,
	26,
	143,
	173,
	719,
	719,
	2071,
	2072,
	137,
	137,
	2073,
	2074,
	2075,
	2076,
	1909,
	2077,
	2078,
	2079,
	137,
	21,
	21,
	137,
	21,
	2080,
	21,
	21,
	99,
	99,
	99,
	99,
	263,
	235,
	2081,
	99,
	21,
	2082,
	137,
	137,
	23,
	102,
	32,
	542,
	26,
	102,
	32,
	542,
	26,
	102,
	169,
	2083,
	26,
	102,
	2084,
	1512,
	26,
	102,
	38,
	2085,
	26,
	102,
	38,
	2085,
	26,
	102,
	169,
	2083,
	26,
	102,
	32,
	542,
	26,
	102,
	2086,
	2087,
	26,
	102,
	2084,
	1512,
	26,
	102,
	776,
	1625,
	105,
	102,
	2088,
	2089,
	26,
	26,
	26,
	14,
	26,
	10,
	32,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	14,
	26,
	10,
	32,
	114,
	31,
	114,
	31,
	681,
	142,
	172,
	1927,
	1929,
	1984,
	1984,
	10,
	10,
	1927,
	1927,
	1927,
	1929,
	1929,
	14,
	115,
	1115,
	10,
	23,
	23,
	169,
	23,
	31,
	27,
	26,
	168,
	168,
	26,
	27,
	27,
	27,
	388,
	27,
	1931,
	23,
	3,
	40,
	2067,
	23,
	435,
	1929,
	1929,
	2008,
	2068,
	1929,
	1929,
	2069,
	1929,
	2008,
	2008,
	34,
	115,
	2070,
	37,
	37,
	37,
	37,
	37,
	26,
	26,
	26,
	26,
	26,
	143,
	173,
	26,
	26,
	26,
	23,
	443,
	14,
	34,
	160,
	160,
	26,
	429,
	2090,
	23,
	133,
	133,
	135,
	2091,
	827,
	827,
	135,
	133,
	2092,
	2091,
	1344,
	2093,
	2067,
	435,
	1075,
	1929,
	1929,
	2008,
	2068,
	1929,
	1929,
	2069,
	1929,
	113,
	115,
	37,
	37,
	37,
	37,
	2070,
	37,
	26,
	26,
	26,
	26,
	26,
	143,
	173,
	2008,
	2008,
	34,
	15,
	14,
	23,
	3,
	27,
	32,
	23,
	114,
	14,
	23,
	14,
	32,
	23,
	114,
	14,
	23,
	14,
	32,
	23,
	114,
	14,
	23,
	14,
	32,
	23,
	114,
	14,
	23,
	14,
	32,
	23,
	114,
	14,
	23,
	14,
	32,
	23,
	114,
	14,
	23,
	14,
	3,
	23,
	2094,
	23,
	23,
	23,
	122,
	134,
	122,
	134,
	122,
	134,
	95,
};
static const Il2CppTokenIndexPair s_reversePInvokeIndices[12] = 
{
	{ 0x060000F3, 34 },
	{ 0x060000F4, 35 },
	{ 0x060000F5, 36 },
	{ 0x060000F6, 37 },
	{ 0x060000F7, 38 },
	{ 0x060000F8, 39 },
	{ 0x060000F9, 40 },
	{ 0x060000FA, 41 },
	{ 0x060000FB, 42 },
	{ 0x060000FC, 43 },
	{ 0x060000FD, 44 },
	{ 0x060000FE, 45 },
};
extern const Il2CppCodeGenModule g_LuminMediaPlayerCodeGenModule;
const Il2CppCodeGenModule g_LuminMediaPlayerCodeGenModule = 
{
	"LuminMediaPlayer.dll",
	337,
	s_methodPointers,
	s_InvokerIndices,
	12,
	s_reversePInvokeIndices,
	0,
	NULL,
	0,
	NULL,
	NULL,
};
