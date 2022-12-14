using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SkyHook
{
    /// <summary>
    /// Recorded key updates from SkyHook.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public readonly struct SkyHookEvent
    {
	    /// <summary>
	    /// Epoch ticks to append in <see cref="GetTimeInTicks"/>.
	    /// </summary>
	    private static readonly long EpochTicks = new DateTime(1970,  1, 1).Ticks;
	    
		/// <summary>
		/// Precise time of the key's state update in seconds.
		/// </summary>
		public readonly long TimeSec;
		/// <summary>
		/// Precise time of the key's state update but only contains nanoseconds.
		/// </summary>
		public readonly uint TimeSubsecNano;
		/// <summary>
		/// Whether the key is pressed or released.
		/// </summary>
		public readonly EventType Type;
		/// <summary>
		/// The identified key label from the native assembly.
		/// </summary>
		public readonly KeyLabel Label;
		/// <summary>
		/// The key number that was pressed or released.
		/// </summary>
		public readonly ushort Key;

		/// <summary>
		/// Returns the sum of <see cref="TimeSec"/> and <see cref="TimeSubsecNano"/> in ticks.
		/// </summary>
		/// <returns>The sum of <see cref="TimeSec"/> and <see cref="TimeSubsecNano"/> in ticks.</returns>
		public long GetTimeInTicks()
			=> (TimeSec * 10000000) + (TimeSubsecNano / 100) + EpochTicks;
    }

    /// <summary>
    /// The type of <see cref="SkyHookEvent"/>'s event.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum EventType
    {
		KeyPressed,
		KeyReleased
    }

    /// <summary>
    /// The key label identified by native SkyHook.
    /// This label will be the same regardless of what OS the player is in.
    /// <br/>
    /// This is a direct import of the https://git.pikokr.dev/SkyHook/SkyHook/src/branch/main/skyhook/src/keycodes.rs native enum.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum KeyLabel : ushort
    {
	    Escape,

	    // Function Keys
	    F1,
	    F2,
	    F3,
	    F4,
	    F5,
	    F6,
	    F7,
	    F8,
	    F9,
	    F10,
	    F11,
	    F12,
	    F13,
	    F14,
	    F15,
	    F16,
	    F17,
	    F18,
	    F19,
	    F20,
	    F21,
	    F22,
	    F23,
	    F24,

	    // 2nd Layer
	    Grave,
	    Alpha1,
	    Alpha2,
	    Alpha3,
	    Alpha4,
	    Alpha5,
	    Alpha6,
	    Alpha7,
	    Alpha8,
	    Alpha9,
	    Alpha0,
	    Minus,
	    Equal,
	    Backspace,

	    // 3rd Layer
	    Tab,
	    Q,
	    W,
	    E,
	    R,
	    T,
	    Y,
	    U,
	    I,
	    O,
	    P,
	    LeftBrace,
	    RightBrace,
	    BackSlash,

	    // 4th Layer
	    CapsLock,
	    A,
	    S,
	    D,
	    F,
	    G,
	    H,
	    J,
	    K,
	    L,
	    Semicolon,
	    Apostrophe,
	    Enter,

	    // 5th Layer
	    LShift,
	    Z,
	    X,
	    C,
	    V,
	    B,
	    N,
	    M,
	    Comma,
	    Dot,
	    Slash,
	    RShift,

	    // 6th Layer
	    LControl,
	    Super,
	    LAlt,
	    Space,
	    RAlt,
	    RControl,

	    // Controls
	    PrintScreen,
	    ScrollLock,
	    PauseBreak,
	    Insert,
	    Home,
	    PageUp,
	    Delete,
	    End,
	    PageDown,
	    ArrowUp,
	    ArrowLeft,
	    ArrowDown,
	    ArrowRight,

	    // Keypad
	    NumLock,
	    KeypadSlash,
	    KeypadAsterisk,
	    KeypadMinus,
	    Keypad1,
	    Keypad2,
	    Keypad3,
	    Keypad4,
	    Keypad5,
	    Keypad6,
	    Keypad7,
	    Keypad8,
	    Keypad9,
	    Keypad0,
	    KeypadDot,
	    KeypadPlus,
	    KeypadEnter,

	    // Mouse
	    MouseLeft,
	    MouseRight,
	    MouseMiddle,
	    MouseX1,
	    MouseX2,

	    // Uncategorized
	    Unknown
    }
}
