# Valheim Incompatibility Fix

So you ran into a problem that one mod has a forced incompatibility with another one? The fix for this is rather easy if the error you get is this:

``[Error  :   BepInEx] Could not load [Almost Perfect Mod 1.0.0] because it is incompatible with: com.puszkapotato.aperfectmod``

Go [Here](#how-to-remove-incompatibility-hex-editing) if you want to get to the how-to.

If you want to know why it happens keep reading what's below.

## Why is this mod incompatible with another?

It depends on the scenario. Sometimes mods are actually incompatible and BepInEx (Mod Loader) has a built-in function to prevent a mod loading if it detects another one, but usually, if the mods are truly incompatible the mod authors inform the user and maybe disable a part of their mod that is incompatible.

The built-in method in BepInEx is unfortunately often used to simply block players from using a mod that the developer of another mod doesn't like for some reason. I won't bring up any examples.

### What is this magical method?

It's a line of code that can look like this.

``[BepInIncompatibility("com.puszkapotato.aperfectmod")]``

The first part is self-explanatory, it simply tells BepInEx that your mod is incompatible with another mod and to not load it. The part in the quotes is a **Mod Identifier**, so pretty much an ID. In BepInEx it is usually called plugin GUID.

### How do we remove this incompatibility?

There are two options, if you have access to the source code then it's usually at the top of the main file. If you don't have access to the source code then you can use HEX editing, this method is described in the How-To a bit lower in the guide.

#### Source Code

But let's continue with an example of how it looks inside an example mod source code. Keep in mind that actual mods have much more code written. This example mod will not run if a mod with an ID ``com.puszkapotato.aperfectmod`` is present.

```csharp
using BepInEx;
using UnityEngine;

namespace AlmostPerfectMod
{
    // Plugin GUID, Name and version
    [BepInPlugin("com.puszkapotato.almostperfectmod", "Almost Perfect Mod", "1.0.0")]

    // Force incompatibility with another mod
    [BepInIncompatibility("com.puszkapotato.aperfectmod")]
    public class AlmostPerfectMod : BaseUnityPlugin
    {
        void Awake()
        {
            // This method is called when the game initializes
            Logger.LogInfo("Almost Perfect Mod Loaded!");
        }
    }
}
```

To remove this incompatibility in the source code we would simply remove line 10.

``[BepInIncompatibility("com.puszkapotato.aperfectmod")]``

This will leave us with the example below and allow us to use this mod with a mod that uses an ID ``com.puszkapotato.aperfectmod``.

```csharp
using BepInEx;
using UnityEngine;

namespace AlmostPerfectMod
{
    // Plugin GUID, Name and version
    [BepInPlugin("com.puszkapotato.almostperfectmod", "Almost Perfect Mod", "1.0.0")]

    public class AlmostPerfectMod : BaseUnityPlugin
    {
        void Awake()
        {
            // This method is called when the game initializes
            Logger.LogInfo("Almost Perfect Mod Loaded!");
        }
    }
}
```

## How To Remove Incompatibility (HEX Editing)

First, I'd like to tell you how this method works. We will use the Hex viewer tool to change a part of code in a mod that has forced incompatibility with another one. The plugin GUID may be different in your situation, but in this example, it will be ``com.puszkapotato.aperfectmod``.

You will need plugin GUID to continue if you don't know how to get go [HERE](#how-to-find-plugin-guid)

1. Make a copy of the mod that is not starting due to incompatibility.
2. Download a HEX Editor/Viewer tool. I will be using HxD64.
3. Open the tool, here's a screenshot of how it looks for me when I open my tool.

![HxD64 start window](/guide/hxd1.png)

4. Open the file of the mod that is not starting due to incompatibility, in my example almostperfectmod.dll

![HxD64 File > Open](/guide/hxd2.png)

5. Now navigate to a directory where you have the mod.

![HxD64 Choose File](/guide/hxd3.png)

6. After you choose the file and press "Open", the file will be loaded in your tool and a bunch of numbers and characters will show up. Don't panic that's what we want. I won't go into the details of all of this, but simply, it's a set of instructions that this file has inside. I am not even close to being proficient in HEX editing to explain it in detail.

![HxD64 Loaded File](/guide/hxd4.png)

7. Find the plugin GUID that is blocking this mod from running, in my example I will be looking for ``com.puszkapotato.aperfectmod``. In HxD64 you can search for a string by going to the Search > Find, or by using a shortcut CTRL + F.

![HxD64 Search Window](/guide/hxd5.png)

8. Enter the plugin GUID of the mod that is blocking this one from running and click "OK" or "Search". If you don't know plugin GUID go [HERE](#how-to-find-plugin-guid).

![HxD64 Found String](/guide/hxd6.png)

9. If you did everything right, then this is what will be shown after you search for the plugin GUID. We want to edit any part of the text that is highlighted. We edit it because we need to keep the same length of the string, so we can't add or remove any characters, only replace them. I will replace ``com.puszkapotato.aperfectmod`` with ``com.puszkapotato.apurfectmod``. As you can see in the screenshot below, after I edited "e" to "u", it's highlighted in red, showing me that I made an edit here. After our edit, we can save the file by going to File > Save or by using a shortcut CTRL + S.

![HxD64 Edited String](/guide/hxd7.png)

10. Copy the edited file into the mods folder and try running the game. The mod should start now without bickering about incompatibility. FYI, some mods might have built-in anti-temper protections which protect them from HEX Editing. In these situations removing incompatibility might be impossible without having access to the source code or relevant knowledge and skills to break this protection.

### How To Find Plugin GUID

Before we start removing the incompatibility we need to find out the plugin GUID of the mod that causes the incompatibility with our mod. We can find it in the logs after we run the game with both mods. You can see in a screenshot below the line that I highlighted. In this case the Plugin GUID is ``com.puszkapotato.aperfectmod``.

![LogOutput Incompatibility Example](/guide/logoutput.png)
