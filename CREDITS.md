# Credits and third-party content

This repository redistributes a large amount of third-party content: roughly
130 MB of the ~132.5 MB committed here. The project's own source is under 1 MB.
**None of the third-party content is covered by the MIT License in
`LICENSE.txt`** - see the scope note at the top of that file.

Sizes and file counts below were taken from the repository tree itself
(`git/trees/master?recursive=1`, 2,749 blobs, 138,988,749 bytes).

## Unity XR Simulation Environments

| Path | Size | File count | What it is |
|---|---|---|---|
| `Assets/UnityXRContent/ARFoundation/SimulationEnvironments/` | 53.71 MB | 1,752 | The unpacked simulation environments (Backyard, Bedroom, Billboard, DiningRoom, Factory, Kitchen, LivingRoom, Museum, Office, Park, PostProcessing, Common) |
| `Assets/UnityXRContent/Common/` | 2.85 MB | 65 | Reference images, objects and shapes |
| `ContentPackages/com.unity.xr-content.xr-sim-environments-1.0.0.tgz` | 35.37 MB (37,088,221 bytes) | 1 | The package tarball itself, referenced from `Packages/manifest.json` as `file:../ContentPackages\com.unity.xr-content.xr-sim-environments-1.0.0.tgz` |

XR Simulation Environments copyright (c) 2022 Unity Technologies ApS, licensed
under the **Unity Package Distribution License**.

Source of that statement: `LICENSE.md` in
<https://github.com/Unity-Technologies/com.unity.xr-content.xr-sim-environments>,
on branch `1.0/release` (the branch whose
`com.unity.xr-content.xr-sim-environments/package.json` declares version
`1.0.0`, matching the tarball above) and identically on branch `source` (the
branch that carries the unpacked `UnityXRContent/` tree). It reads:

> XR Simulation Environments copyright (c) 2022 Unity Technologies ApS
>
> Licensed under the Unity Package Distribution License (see
> https://unity3d.com/legal/licenses/Unity_Package_Distribution_License ).

**That license does not permit what this repository does with the content.**
By its terms it is *non-sublicensable*, and the distribution right it grants
is limited to distributing the work "as binaries integrated with your Project
Content". Committing the tarball and the unpacked source assets to a public
repository is neither. The MIT License in `LICENSE.txt` cannot be applied to
this content, and nothing here should be taken as permission to redistribute
it - if you want these environments, install the package from Unity.

## AR Foundation sample content (`Assets/EX/`, 0.22 MB, 41 files)

`Assets/EX/` was imported from Unity's AR Foundation Samples project,
<https://github.com/Unity-Technologies/arfoundation-samples>. Confirmed
correspondences:

* `Assets/EX/Textures/PlanePatternDot.png` is **byte-identical** (MD5
  `434dbdeaf1aea051a7dc909608327667`) to `Assets/Textures/PlanePatternDot.png`
  in that repository.
* `Assets/EX/Scripts/ARFeatheredPlaneMeshVisualizer.cs` corresponds to
  `Assets/Scripts/Runtime/ARFeatheredPlaneMeshVisualizer.cs` there, and
  `Assets/EX/Shaders/FeatheredPlaneShader.shader` to
  `Assets/Shaders/FeatheredPlaneShader.shader`. Both differ in content from the
  current upstream revision, as expected for files imported in 2023; the exact
  upstream revision has not been pinned.
* `Assets/EX/Scripts/AnchorCreator.cs` is sample code of the same family but is
  not present in the current upstream default branch, so its source revision is
  unconfirmed. Treat it as Unity Companion License content.
* The remaining files in `Assets/EX/` (materials, `Models/cube.fbx`,
  `Prefabs/`, `Scenes/SampleScene.unity`) came in with the same import and
  should be treated the same way.

AR Foundation Samples copyright (c) 2020 Unity Technologies ApS, licensed under
the **Unity Companion License**. Source: `LICENSE.md` in that repository:

> AR Foundation Samples copyright (c) 2020 Unity Technologies ApS
>
> Licensed under the Unity Companion License for Unity-dependent projects--see
> [Unity Companion License](http://www.unity3d.com/legal/licenses/Unity_Companion_License).

The Unity Companion License grant is limited to creating, using and
distributing content made under a valid Unity engine license; the MIT License
does not carry that condition and so cannot be substituted for it.

`Assets/Prefabs/ARPlane.prefab` is **not** original work either: it differs
from `Assets/EX/Prefabs/ARPlane.prefab` by exactly one value (`m_Size`
`{0.01, 0.01, 0.01}` instead of `{0.1, 0.1, 0.1}`). It is excluded from the MIT
scope for that reason.

`Assets/EX/Tutorial/` holds In-Editor Tutorial content associated with the
`com.unity.learn.iet-framework` package (declared as `3.1.3` in
`Packages/manifest.json`), copyright Unity Technologies.

## Art and UI packs

| Directory | Size | Files | Pack / origin | Terms |
|---|---|---|---|---|
| `Assets/Pure Poly/Free Low Poly Nature Pack/` | 1.94 MB | 112 | Publisher **Pure Poly**. The pack's bundled `Read Me.pdf` gives the contact address `Purepoly.info@gmail.com` and points to the publisher's store; all meshes use the publisher's `PP_` prefix. The current Unity Asset Store listing under that publisher is "Free Low Poly Nature Forest" (package 205742); the in-repo folder name differs, so the exact listing and version are not pinned. | Unity Asset Store content - Standard Unity Asset Store EULA, Extension Asset, free of charge. Not redistributable under the MIT License. |
| `Assets/Buttons/` | 25.52 MB | 70, including a 24.5 MB layered `buttons.psd` | **Origin unconfirmed.** The directory has the layout of an imported Unity Asset Store UI package (`PNG/` with 30 numbered button sprites, `Scenes/SampleScene.unity`, a source `.psd`) but carries no readme, license file, or publisher metadata - the `.meta` files have empty `userData`, and web searches on the distinctive filenames (`Button_Midl_*`, `bttn-little`, `buttons_Back.png`) did not identify the publisher. | **Unknown. Treat as all rights reserved.** Given the layout, the Standard Unity Asset Store EULA most likely applies, but that has not been established. |
| `Assets/FreeButtonSet/` | 1.15 MB | 230 | **Origin unconfirmed.** Same situation: `Textures/{buttons,controls,icons}` with icons at 32/64/128/256 px, a `Scenes/SampleScene.unity`, and bundled Poppins fonts, but no readme, license file, or publisher metadata, and searches on the folder and file names did not identify it. | **Unknown. Treat as all rights reserved.** Bundles the Poppins font (below), which carries its own license. |
| `Assets/TextMesh Pro/` | 8.81 MB | 322 | TextMesh Pro Essential Resources and Examples & Extras, Unity Technologies (ships with `com.unity.textmeshpro`, declared as `3.0.6` in `Packages/manifest.json`) | Unity's package terms; the bundled fonts are under the SIL Open Font License - see `Fonts/LiberationSans - OFL.txt`, `Examples & Extras/Fonts/{Anton OFL.txt, Bangers - OFL.txt, Oswald-Bold - OFL.txt}` and `Sprites/EmojiOne Attribution.txt` in that directory. |

If you know the origin of either button pack, please open an issue so this file
can be corrected.

## Fonts

`Assets/FreeButtonSet/Fonts/Poppins-Bold.ttf` and `Poppins-MediumItalic.ttf` -
**Poppins**, Indian Type Foundry. Taken from the fonts' own embedded name
table, not from a third-party description:

* Copyright: `Copyright 2014-2017 Indian Type Foundry (info@indiantypefoundry.com)`
* Designers: `Ninad Kale (Devanagari), Jonny Pinhorn (Latin)`
* License: `This Font Software is licensed under the SIL Open Font License,
  Version 1.1. This license is available with a FAQ at:
  http://scripts.sil.org/OFL`

The OFL permits redistribution with the copyright and license notice retained;
neither font ships with a copy of the OFL text in this repository, which is why
the notice is reproduced here.

## Files with no recorded provenance

Not covered by `LICENSE.txt`:

* `Assets/PhoneOnTheTable.png` (0.12 MB)
* `Assets/Prefabs/Free_Forest.prefab` (2.35 MB) - composed from Pure Poly meshes
* `Assets/Simulation Environment.prefab` - references `Assets/UnityXRContent/`
* `Assets/XR/` and `Assets/Plugins/` - settings assets generated by Unity's XR
  packages

## Limits of this attribution

* The primary license texts are published on Unity's own site, which returns
  HTTP 403 to automated fetches. The **names** of the licenses above were read
  first-hand from the `LICENSE.md` files in Unity's own GitHub repositories and
  are quoted above. The **contents** of those licenses were read from copies
  hosted elsewhere: the Unity Package Distribution License (v2.0) from a
  third-party mirror on GitHub, and the Unity Companion License from Unity's
  own documentation site (`docs.unity3d.com`, package license page). The
  characterisations here - "non-sublicensable", "binaries integrated with your
  Project Content", "valid Unity engine license" - reflect those copies. For
  anything that matters, read the authoritative texts at
  <https://unity.com/legal/licenses/unity-package-distribution-license> and
  <https://unity.com/legal/licenses/unity-companion-license>.
* This file records what is here and under what terms. It does not cure the
  underlying problem: content that is not redistributable is still committed to
  a public repository. The sharpest cases are the XR Simulation Environments
  tarball and unpacked assets (non-sublicensable, ~92 MB combined) and the two
  unidentified button packs.
