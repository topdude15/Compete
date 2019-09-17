#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>
#include <stdint.h>

#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"


// System.Action
struct Action_t591D2A86165F896B4B800BB5C25CE18672A55579;
// System.AsyncCallback
struct AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4;
// System.DelegateData
struct DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE;
// System.Delegate[]
struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;
// System.IAsyncResult
struct IAsyncResult_t8E194308510B375B42432981AE5E7488C458D598;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.Void
struct Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017;

IL2CPP_EXTERN_C RuntimeClass* Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C const RuntimeMethod* Lifecycle_InvokePauseEvent_mEF377657C305847C01E036F94E84A9CCD9DB4BBE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Lifecycle_InvokeResumeEvent_m05AF8DE9970039599337FD96FC640CB09ED0D5DB_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Lifecycle_InvokeStopEvent_mB73D757550566690030B795FF747C9765DD8FA93_RuntimeMethod_var;
IL2CPP_EXTERN_C const uint32_t Lifecycle_InvokePauseEvent_mEF377657C305847C01E036F94E84A9CCD9DB4BBE_MetadataUsageId;
IL2CPP_EXTERN_C const uint32_t Lifecycle_InvokeResumeEvent_m05AF8DE9970039599337FD96FC640CB09ED0D5DB_MetadataUsageId;
IL2CPP_EXTERN_C const uint32_t Lifecycle_InvokeStopEvent_mB73D757550566690030B795FF747C9765DD8FA93_MetadataUsageId;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_t77882E343B0EA3706F631D89562F2686F00C2770 
{
public:

public:
};


// System.Object

struct Il2CppArrayBounds;

// System.Array


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

// UnityEngine.Lumin.Lifecycle
struct  Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B  : public RuntimeObject
{
public:

public:
};

struct Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_StaticFields
{
public:
	// System.Action UnityEngine.Lumin.Lifecycle::pauseEvent
	Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * ___pauseEvent_0;
	// System.Action UnityEngine.Lumin.Lifecycle::resumeEvent
	Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * ___resumeEvent_1;
	// System.Action UnityEngine.Lumin.Lifecycle::stopEvent
	Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * ___stopEvent_2;

public:
	inline static int32_t get_offset_of_pauseEvent_0() { return static_cast<int32_t>(offsetof(Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_StaticFields, ___pauseEvent_0)); }
	inline Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * get_pauseEvent_0() const { return ___pauseEvent_0; }
	inline Action_t591D2A86165F896B4B800BB5C25CE18672A55579 ** get_address_of_pauseEvent_0() { return &___pauseEvent_0; }
	inline void set_pauseEvent_0(Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * value)
	{
		___pauseEvent_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___pauseEvent_0), (void*)value);
	}

	inline static int32_t get_offset_of_resumeEvent_1() { return static_cast<int32_t>(offsetof(Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_StaticFields, ___resumeEvent_1)); }
	inline Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * get_resumeEvent_1() const { return ___resumeEvent_1; }
	inline Action_t591D2A86165F896B4B800BB5C25CE18672A55579 ** get_address_of_resumeEvent_1() { return &___resumeEvent_1; }
	inline void set_resumeEvent_1(Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * value)
	{
		___resumeEvent_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___resumeEvent_1), (void*)value);
	}

	inline static int32_t get_offset_of_stopEvent_2() { return static_cast<int32_t>(offsetof(Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_StaticFields, ___stopEvent_2)); }
	inline Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * get_stopEvent_2() const { return ___stopEvent_2; }
	inline Action_t591D2A86165F896B4B800BB5C25CE18672A55579 ** get_address_of_stopEvent_2() { return &___stopEvent_2; }
	inline void set_stopEvent_2(Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * value)
	{
		___stopEvent_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___stopEvent_2), (void*)value);
	}
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


// System.Delegate
struct  Delegate_t  : public RuntimeObject
{
public:
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject * ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t * ___method_info_7;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t * ___original_method_info_8;
	// System.DelegateData System.Delegate::data
	DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * ___data_9;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_10;

public:
	inline static int32_t get_offset_of_method_ptr_0() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_ptr_0)); }
	inline Il2CppMethodPointer get_method_ptr_0() const { return ___method_ptr_0; }
	inline Il2CppMethodPointer* get_address_of_method_ptr_0() { return &___method_ptr_0; }
	inline void set_method_ptr_0(Il2CppMethodPointer value)
	{
		___method_ptr_0 = value;
	}

	inline static int32_t get_offset_of_invoke_impl_1() { return static_cast<int32_t>(offsetof(Delegate_t, ___invoke_impl_1)); }
	inline intptr_t get_invoke_impl_1() const { return ___invoke_impl_1; }
	inline intptr_t* get_address_of_invoke_impl_1() { return &___invoke_impl_1; }
	inline void set_invoke_impl_1(intptr_t value)
	{
		___invoke_impl_1 = value;
	}

	inline static int32_t get_offset_of_m_target_2() { return static_cast<int32_t>(offsetof(Delegate_t, ___m_target_2)); }
	inline RuntimeObject * get_m_target_2() const { return ___m_target_2; }
	inline RuntimeObject ** get_address_of_m_target_2() { return &___m_target_2; }
	inline void set_m_target_2(RuntimeObject * value)
	{
		___m_target_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_target_2), (void*)value);
	}

	inline static int32_t get_offset_of_method_3() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_3)); }
	inline intptr_t get_method_3() const { return ___method_3; }
	inline intptr_t* get_address_of_method_3() { return &___method_3; }
	inline void set_method_3(intptr_t value)
	{
		___method_3 = value;
	}

	inline static int32_t get_offset_of_delegate_trampoline_4() { return static_cast<int32_t>(offsetof(Delegate_t, ___delegate_trampoline_4)); }
	inline intptr_t get_delegate_trampoline_4() const { return ___delegate_trampoline_4; }
	inline intptr_t* get_address_of_delegate_trampoline_4() { return &___delegate_trampoline_4; }
	inline void set_delegate_trampoline_4(intptr_t value)
	{
		___delegate_trampoline_4 = value;
	}

	inline static int32_t get_offset_of_extra_arg_5() { return static_cast<int32_t>(offsetof(Delegate_t, ___extra_arg_5)); }
	inline intptr_t get_extra_arg_5() const { return ___extra_arg_5; }
	inline intptr_t* get_address_of_extra_arg_5() { return &___extra_arg_5; }
	inline void set_extra_arg_5(intptr_t value)
	{
		___extra_arg_5 = value;
	}

	inline static int32_t get_offset_of_method_code_6() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_code_6)); }
	inline intptr_t get_method_code_6() const { return ___method_code_6; }
	inline intptr_t* get_address_of_method_code_6() { return &___method_code_6; }
	inline void set_method_code_6(intptr_t value)
	{
		___method_code_6 = value;
	}

	inline static int32_t get_offset_of_method_info_7() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_info_7)); }
	inline MethodInfo_t * get_method_info_7() const { return ___method_info_7; }
	inline MethodInfo_t ** get_address_of_method_info_7() { return &___method_info_7; }
	inline void set_method_info_7(MethodInfo_t * value)
	{
		___method_info_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___method_info_7), (void*)value);
	}

	inline static int32_t get_offset_of_original_method_info_8() { return static_cast<int32_t>(offsetof(Delegate_t, ___original_method_info_8)); }
	inline MethodInfo_t * get_original_method_info_8() const { return ___original_method_info_8; }
	inline MethodInfo_t ** get_address_of_original_method_info_8() { return &___original_method_info_8; }
	inline void set_original_method_info_8(MethodInfo_t * value)
	{
		___original_method_info_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___original_method_info_8), (void*)value);
	}

	inline static int32_t get_offset_of_data_9() { return static_cast<int32_t>(offsetof(Delegate_t, ___data_9)); }
	inline DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * get_data_9() const { return ___data_9; }
	inline DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE ** get_address_of_data_9() { return &___data_9; }
	inline void set_data_9(DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * value)
	{
		___data_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___data_9), (void*)value);
	}

	inline static int32_t get_offset_of_method_is_virtual_10() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_is_virtual_10)); }
	inline bool get_method_is_virtual_10() const { return ___method_is_virtual_10; }
	inline bool* get_address_of_method_is_virtual_10() { return &___method_is_virtual_10; }
	inline void set_method_is_virtual_10(bool value)
	{
		___method_is_virtual_10 = value;
	}
};

// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * ___data_9;
	int32_t ___method_is_virtual_10;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * ___data_9;
	int32_t ___method_is_virtual_10;
};

// System.MulticastDelegate
struct  MulticastDelegate_t  : public Delegate_t
{
public:
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* ___delegates_11;

public:
	inline static int32_t get_offset_of_delegates_11() { return static_cast<int32_t>(offsetof(MulticastDelegate_t, ___delegates_11)); }
	inline DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* get_delegates_11() const { return ___delegates_11; }
	inline DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86** get_address_of_delegates_11() { return &___delegates_11; }
	inline void set_delegates_11(DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* value)
	{
		___delegates_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___delegates_11), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_11;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_11;
};

// System.Action
struct  Action_t591D2A86165F896B4B800BB5C25CE18672A55579  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void System.Action::Invoke()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_Invoke_mC8D676E5DDF967EC5D23DD0E96FB52AA499817FD (Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * __this, const RuntimeMethod* method);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.Lumin.Lifecycle::InvokePauseEvent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Lifecycle_InvokePauseEvent_mEF377657C305847C01E036F94E84A9CCD9DB4BBE (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Lifecycle_InvokePauseEvent_mEF377657C305847C01E036F94E84A9CCD9DB4BBE_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	StackTraceSentry _stackTraceSentry(Lifecycle_InvokePauseEvent_mEF377657C305847C01E036F94E84A9CCD9DB4BBE_RuntimeMethod_var);
	{
		Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * L_0 = ((Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_StaticFields*)il2cpp_codegen_static_fields_for(Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_il2cpp_TypeInfo_var))->get_pauseEvent_0();
		if (!L_0)
		{
			goto IL_0015;
		}
	}
	{
		Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * L_1 = ((Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_StaticFields*)il2cpp_codegen_static_fields_for(Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_il2cpp_TypeInfo_var))->get_pauseEvent_0();
		NullCheck(L_1);
		Action_Invoke_mC8D676E5DDF967EC5D23DD0E96FB52AA499817FD(L_1, /*hidden argument*/NULL);
	}

IL_0015:
	{
		return;
	}
}
// System.Void UnityEngine.Lumin.Lifecycle::InvokeResumeEvent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Lifecycle_InvokeResumeEvent_m05AF8DE9970039599337FD96FC640CB09ED0D5DB (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Lifecycle_InvokeResumeEvent_m05AF8DE9970039599337FD96FC640CB09ED0D5DB_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	StackTraceSentry _stackTraceSentry(Lifecycle_InvokeResumeEvent_m05AF8DE9970039599337FD96FC640CB09ED0D5DB_RuntimeMethod_var);
	{
		Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * L_0 = ((Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_StaticFields*)il2cpp_codegen_static_fields_for(Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_il2cpp_TypeInfo_var))->get_resumeEvent_1();
		if (!L_0)
		{
			goto IL_0015;
		}
	}
	{
		Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * L_1 = ((Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_StaticFields*)il2cpp_codegen_static_fields_for(Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_il2cpp_TypeInfo_var))->get_resumeEvent_1();
		NullCheck(L_1);
		Action_Invoke_mC8D676E5DDF967EC5D23DD0E96FB52AA499817FD(L_1, /*hidden argument*/NULL);
	}

IL_0015:
	{
		return;
	}
}
// System.Void UnityEngine.Lumin.Lifecycle::InvokeStopEvent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Lifecycle_InvokeStopEvent_mB73D757550566690030B795FF747C9765DD8FA93 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Lifecycle_InvokeStopEvent_mB73D757550566690030B795FF747C9765DD8FA93_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	StackTraceSentry _stackTraceSentry(Lifecycle_InvokeStopEvent_mB73D757550566690030B795FF747C9765DD8FA93_RuntimeMethod_var);
	{
		Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * L_0 = ((Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_StaticFields*)il2cpp_codegen_static_fields_for(Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_il2cpp_TypeInfo_var))->get_stopEvent_2();
		if (!L_0)
		{
			goto IL_0015;
		}
	}
	{
		Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * L_1 = ((Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_StaticFields*)il2cpp_codegen_static_fields_for(Lifecycle_t802A073D8DCD908DFCCFED237D0EFE728C3F8C3B_il2cpp_TypeInfo_var))->get_stopEvent_2();
		NullCheck(L_1);
		Action_Invoke_mC8D676E5DDF967EC5D23DD0E96FB52AA499817FD(L_1, /*hidden argument*/NULL);
	}

IL_0015:
	{
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
