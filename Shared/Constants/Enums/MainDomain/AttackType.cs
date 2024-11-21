using System.ComponentModel;

namespace Shared.Constants.Enums.MainDomain {
    public enum AttackType : byte {
        [Description("Loss of consciousness, muscle contractions, falling, rhythmic muscle contractions")]
        lcmf = 0,
        [Description("Severe contraction and shaking of hands and feet")]
        sshf = 1,
        [Description("Sudden contraction of the leg, arm, and neck (similar to a tic) with rapid repetition (shaking and jumping one after another)")]
        sclan = 2,
        [Description("Repetitive shaking")]
        rs = 3,
        [Description("Sudden discharge and falling to the ground")]
        sdfg = 4,
        [Description("Staring at a point in an unconscious state, sometimes with hand twitching or chewing movements (atypical absence)")]
        sapa = 5,
        [Description("With preserved consciousness, experiencing a sudden feeling like dizziness, nausea, etc.")]
        cpc = 6,
        [Description("Unawareness of the attack and at the same time unaware of talking to others with strange and irrelevant responses")]
        uar = 7,
        [Description("Staring at a point, repeating a movement, seeing strange things like colors and plants, or recalling an event from years ago")]
        sarp = 8,
    }
}
