![pack.png](https://i.loli.net/2018/02/18/5a8974407b453.png)
---
**Languages/语言:** [中文](README.md) [**English**](README.md)

| CurseForge Downloads | Versions Supported | Localization Progress | Github Actions | Latest Snapshot |
| :--: | :--: | :--: | :--: | :--: |
| [![CurseForge](http://cf.way2muchnoise.eu/full_simplified-chinese-localization-resource-package_downloads.svg)](https://minecraft.curseforge.com/projects/simplified-chinese-localization-resource-package) | [![CurseForge](http://cf.way2muchnoise.eu/versions/simplified-chinese-localization-resource-package.svg)](https://minecraft.curseforge.com/projects/simplified-chinese-localization-resource-package)  | ![weblate](https://weblate-t.exz.me/widgets/langpack/-/svg-badge.svg) | ![Packer](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/workflows/Packer/badge.svg?branch=main) | [![GitHub release](https://img.shields.io/github/release/CFPAOrg/Minecraft-Mod-Language-Package.svg)](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/releases/latest) |

## About this Repository

Here is the repository of the project for translating Minecraft mods. The project is currectly using Weblate to translate.<br>
This project aim to tackle issues such as the tardiness when localizations are submitted or waiting to be accepted by modders.<br>
If you want to join us to translate together, please visit our official website and read the information detail:<br>
### <https://cfpa.team>

It is also fine to submit pull requests to this repository.

Before translating, you should first learn important things from here: [*Regulations and Guidelines for Simplified Chinese Translation of Minecraft Mods*](https://github.com/Meow-J/Mod-Translation-Styleguide/blob/master/README.md).

## Authorizations

This work is licensed under a [Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License](https://creativecommons.org/licenses/by-nc-sa/4.0/)([Simplified Chinese](https://creativecommons.org/licenses/by-nc-sa/4.0/deed.zh)). The full text of this license can be found [here](./LICENSE).<br>

## Usage

Download the resource pack of *release* version on CourseForge from [this](https://minecraft.curseforge.com/projects/simplified-chinese-localization-resource-package) portal.<br>
Download the resource pack of *snapshot* version on CourseForge from [this](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/releases/latest) portal.<br>
To apply the localization, you need only to load this pack like any other resource pack. In case of some issues, restarting the game after loading  is recommended.

## Related Information

**How does the current localization project look like? Can I submit my list of mods that I want them to be translated?**<br>
Currently, according to the popularity on CurseForge, we have chosen the 1.12.2 version and are tracking over 1000 mods. If you want any additional mod to be translated, you can suggest your ideas through our [bug tracker](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/issues), or by sending emails to us.<br>
We have no plans for other versions so far (but 1.7.10 is unlikely to be considered).

There are some detailed publicity on [the MCBBS page](http://www.mcbbs.net/thread-774087-1-1.html).

The whole story of this project can be seen in [TartaricAcid's blog post](https://baka943.coding.me/2018/01/03/2018-01-03-AnIntroForWeblate/).

**How is it possible for your guys to achieve such a pipelining translating style?**<br>
Ummmm, it's easy though:<br>

- Get the popular mods on CurseForge with the web scraper.
- Push the files to the GitHub repository with scripts
- Get the updates from GitHub automatically when Weblate detects changes in repositories.
- The translators translate on Weblate, and Weblate push the changes to GitHub automatically.
- Github Actions builds and packs automatically when detecting changes in the repository.
- Github Actions publish packs to the GitHub release automatically so that the packs can be downloaded.

## Thanks

Thanks `phi` for building the Weblate server and automatic translation functionality.<br>
Thanks `Summpot` and`Nullpinter` for making the C# web scraper of newer versions.<br>
Thanks `PeakXing` for making the logo.<br>
Thanks `雪尼`、`FledgeXu`、`asdflj` et al. for suggestions and ideas.<br>
Thanks the first few contributors of this project: `Aemande123`，`DYColdWind`，`Snownee`，`yuanjie000`，`forestbat`，`3TUSK`，`SihenZhang`，`MoXiaoFreak`，`gloomy_banana`，`yuanjie000`，`exia00125`，`luckyu19` for localizations (in no particular order).<br>
Thanks `R_liu`  for the localization of mod SlashBalde.<br>
Thanks `3TUSK` for providing the [fixes for full-angle symbols](./project/assets/minecraft/readme.md) which are embedded in the resource pack.<br>
Finally, give thanks to the great efforts of every player who engages in providing and spreading localizations.<br>
See all the contributors in the [Contributors](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/graphs/contributors) page of this repository.
