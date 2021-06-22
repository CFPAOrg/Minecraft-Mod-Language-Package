![pack.png](https://i.loli.net/2018/02/18/5a8974407b453.png)
---
**Languages/语言:** [中文](README.md) [**English**](README-en.md)

| CurseForge Downloads | Versions Supported | Localization Progress | Github Actions | Latest Snapshot |
| :--: | :--: | :--: | :--: | :--: |
| [![CurseForge](http://cf.way2muchnoise.eu/full_simplified-chinese-localization-resource-package_downloads.svg)](https://minecraft.curseforge.com/projects/simplified-chinese-localization-resource-package) | [![CurseForge](http://cf.way2muchnoise.eu/versions/simplified-chinese-localization-resource-package.svg)](https://minecraft.curseforge.com/projects/simplified-chinese-localization-resource-package)  | ![weblate](https://weblate-t.exz.me/widgets/langpack/-/svg-badge.svg) | ![Packer](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/workflows/Packer/badge.svg?branch=main) | [![GitHub release](https://img.shields.io/github/release/CFPAOrg/Minecraft-Mod-Language-Package.svg)](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/releases/latest) |

## About this Repository

This is the repository of the project for translating Minecraft mods into simplified Chinese, currectly using a platform called Weblate which is similar to Crowdin.<br>
This project aims to deal with certain problems where localizations are not accepted in time or simply fail to be accepted.<br>
If you want to join us, please visit our official website and learn more:<br>
### <https://cfpa.team>

It is also fine to submit pull requests to this repository.

Before you start, check the important tips from us here: [*Regulations and Guidelines for Simplified Chinese Translation of Minecraft Mods*](https://github.com/Meow-J/Mod-Translation-Styleguide/blob/master/README.md).

## Authorizations

This project is licensed under the [Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License](https://creativecommons.org/licenses/by-nc-sa/4.0/)([Simplified Chinese](https://creativecommons.org/licenses/by-nc-sa/4.0/deed.zh)). Detail can be found [here](./LICENSE).<br>

## Usage

Download the *released* version [here](https://minecraft.curseforge.com/projects/simplified-chinese-localization-resource-package) or the *snapshot* version [here](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/releases/latest).<br>
To apply, simply load this pack like any other resource pack. In case of some issues, restarting Minecraft after loading is recommended.

## Related Information

**How does the current localization project look like? Can I submit my list of mods that I want them to be translated?**<br>
Currently, according to the popularity on CurseForge, we have chosen Minecraft 1.12.2 for the majority of our work, with over 1000 mods in the project. If you want any other mod to be translated, you can suggest through our [issue tracker](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/issues), or email us directly.<br>

We have been propagating this project on [the MCBBS page](http://www.mcbbs.net/thread-774087-1-1.html).

The history of this project can be seen in [TartaricAcid's blog](https://baka943.coding.me/2018/01/03/2018-01-03-AnIntroForWeblate/).

**How did you guys set up the workflow?**<br>
Ummmm, it's easy though:<br>

- Get the popular mods on CurseForge with the web scraper.
- Push the files to the GitHub repository with scripts
- Pull the updates from GitHub to Weblate automatically when detecting changes in the repository.
- The translators translate on Weblate, and Weblate push the changes to GitHub automatically.
- Github Actions builds and packs automatically when detecting changes in the repository.
- Github Actions publish packs to the GitHub release automatically so that the packs can be downloaded.

## Credits

* `phi` for setting up the Weblate server and integration with Google Translate.
* `Summpot` and `Nullpinter` for a better version of the C# web scraper.
* `PeakXing` for making the logo.
* `雪尼`, `FledgeXu`, `asdflj` and others who give suggestions and ideas.
* Pioneers of this project: `Aemande123`, `DYColdWind`, `Snownee`, `yuanjie000`, `forestbat`, `3TUSK`, `SihenZhang`, `MoXiaoFreak`, `gloomy_banana`, `yuanjie000`, `exia00125`, `luckyu19` for early localizations (in no particular order).
* `R_liu`  for the localization of SlashBalde.
* `3TUSK` for [fixing the display of full-width punctuation](./project/assets/minecraft/readme.md). This is originally involved in the pack.
* `LucunJi` for the internationalization of this readme file.
* Finally, give thanks to every single player who engages in providing and spreading localizations.
See all the contributors in the [Contributors](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/graphs/contributors) page.
