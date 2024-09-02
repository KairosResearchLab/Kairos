# Changelog

### 2.0.0
#### General
- Kairos integrated in vvvv as an extension 
- Timeline is now called KeyframeEditor
- GetDefaultKeyframeEditor node to access the default KeyframeEditor associated with the Application and to be able to control its clock
- Launcher1D is now called PresetEditor
- Compositor1D is now called Timeline
- PresetEditor not supported in this first version of the extension
- Timeline (former Compositor1D) not supported in this first version of the extension (Still misses a UI)
- Temporarily no support for patched Kairos compositions UI (no KairosEditor node)
- Temporarily no support for nested compositions
- Temporarily no support for recording features

#### Keyframe Editor
- Keyframe multi-selection (marquee selection)
- Multi-selection translation and snapping
- Horizontal(Ctrl key) / Vertical(Alt key) translation constraints
- Session management: Save, Save As..., Open... , Auto-Save, Auto-Backup
- Track has two modes: curve view when unfolded, Dopesheet view when folded
- Track visibility controlled by Global Channel Extension views (optional)
- Keyframe duration handler visible and interactive when Shift key is pressed

### 1.1.0
#### New
- New recording feature in KeyframeEditor and Launcher1D UI
- New help patches

#### Fixes
- KairosEditor now has persistent model storing UI state

### 1.0.0
#### New
- KeyframeEditor with UI
- Launcher1D with UI
- CompositionSampler with UI
- KairosEditor

### 0.5.8
#### Fixes

- Fixed registration error in vl.kairos.stride

