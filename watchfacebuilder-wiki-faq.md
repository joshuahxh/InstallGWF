# Watchface Builder for Garmin — Wiki & FAQ

> **Welcome to the official wiki and FAQ for [Watchface Builder for Garmin](https://garmin.watchfacebuilder.com) (WFB).** This guide covers everything from getting started to advanced techniques, compiled from community discussions on [r/watchfacebuilder](https://www.reddit.com/r/watchfacebuilder) and the official website.
>
> **Developer:** u/joshuahxh-1
>
> **Moderators:** u/Economy-Annual1219 · u/Joshuahxh

---

## Table of Contents

1. [What Is Watchface Builder for Garmin?](#what-is-watchface-builder-for-garmin)
2. [Getting Started](#getting-started)
3. [Building Your First Watch Face](#building-your-first-watch-face)
4. [Installing Watch Faces on Your Garmin Device](#installing-watch-faces-on-your-garmin-device)
5. [API Keys & Weather Data](#api-keys--weather-data)
6. [Tokens & Data Fields](#tokens--data-fields)
7. [Expressions, Visibility & Math](#expressions-visibility--math)
8. [Custom Fonts & Bitmap Fonts (BMF)](#custom-fonts--bitmap-fonts-bmf)
9. [Images, Icons & Animations](#images-icons--animations)
10. [App Properties & Custom User Settings](#app-properties--custom-user-settings)
11. [Language & Localization](#language--localization)
12. [Battery Life Optimization](#battery-life-optimization)
13. [Memory Optimization](#memory-optimization)
14. [Publishing to Garmin Connect IQ](#publishing-to-garmin-connect-iq)
15. [Premium Membership](#premium-membership)
16. [Troubleshooting Common Errors](#troubleshooting-common-errors)
17. [Known Limitations & Quirks](#known-limitations--quirks)
18. [MIP Display Issues](#mip-display-issues)
19. [Tips & Advanced Techniques](#tips--advanced-techniques)
20. [Privacy & Data Policy](#privacy--data-policy)
21. [Keyboard & Mouse Shortcuts](#keyboard--mouse-shortcuts)
22. [Community Resources](#community-resources)

---

## What Is Watchface Builder for Garmin?

Watchface Builder for Garmin (WFB) is a **free, web-based tool** that lets you design and build custom watch face apps for Garmin devices — **no coding required**. You design visually in a browser-based editor, and WFB generates a working Garmin watch face app (`.prg` file) that you can install on your device.

**Key features include:**

- A drag-and-drop visual editor for designing watch faces
- Support for 100+ Garmin device models
- 679+ data tokens (heart rate, weather, steps, GPS, battery, and much more)
- Custom fonts, images, animated GIFs, and icon support
- Math expressions and visibility conditions for dynamic elements
- App properties for user-customizable settings
- Export to ConnectIQ (`.iq` file) for publishing on the Garmin store (premium)
- Automated simulator testing (premium)
- A dedicated desktop installer app for easy sideloading

---

## Getting Started

### Creating an Account

1. Go to [garmin.watchfacebuilder.com](https://garmin.watchfacebuilder.com).
2. Click **Login | Register** in the top-right corner.
3. Create a free account to save your designs.

### The WFB Interface

- **Home page** — Browse community-created watch faces. You can clone public designs (if the creator allows it) to learn from them or use as a starting point.
- **Builder** — The main editor where you design your watch face. WFB has both a **new editor** and a **legacy editor**. Some users prefer the legacy editor for its simpler layout. Note: editor settings (such as the watch overlay toggle) may not persist between sessions in the legacy editor — you may need to re-apply your preferences each time you open it. The editor uses a widget-based system — objects can be selected by clicking, dragging a selection box, or clicking the widget tile in the panel. Hold Shift to multi-select. Use Shift+Arrow keys for fine-grained movement.
- **Installer** — A desktop companion app (v1.0.3) that helps you transfer watch faces to your device.
- **BMF for Garmin** — The Bitmap Font tool (v2.1.1) for creating custom pixel-perfect fonts.
- **Tokens page** — A searchable reference of all 679+ data tokens available for use in your designs.
- **Send API Key** — Where you configure your WFB API key for weather and location data.

### Choosing Your Device

When you start a new design in the Builder, you select your specific Garmin device model. This is important because each device has a different screen resolution and shape (round, rectangle, etc.). Common resolutions include:

- **176 × 176** — Instinct series
- **260 × 260** — Fenix 7 Pro, some Forerunner models
- **280 × 280** — Fenix 7X, Enduro
- **390 × 390** — Vivoactive 6
- **416 × 416** — Forerunner 265, Epix series
- **454 × 454** — Epix 2 Pro 51mm, Fenix 8 47mm
- **448 × 486** — Venu series

---

## Building Your First Watch Face

### Step-by-Step Basics

1. **Open the Builder** and select your Garmin device model.
2. **Add objects** to the canvas — text fields, images, shapes, lines, arcs, and data fields.
3. **Assign data tokens** to objects to display dynamic information (time, date, heart rate, steps, weather, etc.).
4. **Style your design** by adjusting position (X, Y), size, colors, and fonts.
5. **Use the layer panel** to manage object stacking order. Check "Layer Object" on an image to allow it to appear on top of other objects. Objects can be locked (click the Lock icon on a widget tile) to prevent accidental selection, or hidden (click the Eye icon) to work on layers behind them.
6. **Apply a color palette** (optional) — Click Browse in Global Settings to choose from hundreds of color schemes. Each palette has four variations that change the order colors are applied. You can further customize by dragging the color swatches to rearrange assignments.
7. **Preview** your design in the editor.
8. **Click "Generate"** to build the watch face app.
9. **Download** the `.prg` file (or `.zip` file if it includes app properties).

### Can I Build Without Premium?

**Yes!** The core building features are free. After building, click the download button below the watch face preview to get your `.prg` file. Premium unlocks additional features like ConnectIQ export and simulator testing.

### Can I Get the Source Code (Monkey C) of My Watch Face?

**No.** The generated code is not human-readable and is not designed for manual editing. WFB compiles directly to a binary `.prg` file. If you need custom Monkey C code, you would need to write a ConnectIQ app from scratch using the Garmin SDK.

### Can I Change Predefined App Properties?

Predefined app properties like "OpenWeatherMap API key" and "Auth. User Name" can be customized. This functionality is being improved within WFB, but in the meantime you can follow community guides on r/watchfacebuilder for workarounds.

---

## Installing Watch Faces on Your Garmin Device

This is one of the most frequently asked questions in the community. There are several methods:

### Method 1: Direct USB Sideloading (Most Common)

1. Connect your Garmin watch to your computer via USB cable.
2. Your watch should appear as a removable drive.
3. Navigate to the `GARMIN/Apps` folder on the watch.
4. Copy the downloaded `.prg` file into that folder.
5. Safely disconnect the watch.
6. On the watch, long-press the middle-left button, go to **Watch Face**, and scroll to find your new face.

**Important notes:**
- After a recent Garmin firmware update, `.prg` files only work on the specific device model they were built for. Always select the correct device in the Builder.
- **⚠️ ".PRG file disappeared" — this is the #1 most common question.** After disconnecting, `.prg` files will vanish from the `GARMIN/Apps` folder when you reconnect via USB. **This is completely normal.** Garmin's firmware moves them internally after installation. Your watch face is still installed — long-press the menu button, go to **Watch Face**, and scroll through to find it. Do not keep re-copying the file thinking it failed.

### Method 2: WFB Installer App

The WFB Installer (v1.0.3) is a desktop companion app that simplifies the process:
1. Download and install the WFB Installer from the website.
2. You can drag the downloaded `.zip` file into the installer, or type the watch face URL.
3. Press "Enter" and the program copies the app to your connected device.

### Method 3: ConnectIQ Store (Premium)

1. Export your watch face to a `.iq` file (requires premium membership).
2. Go to [apps.garmin.com/developer/dashboard](https://apps.garmin.com/developer/dashboard) and create a developer account.
3. Upload the `.iq` file and submit it as a beta or publish it publicly.
4. Install from the ConnectIQ store on your phone or computer.

This is the best method if your watch face uses **App Properties** (user-configurable settings), since sideloaded apps cannot display on-device settings menus.

### Method 4: Mac Users

Mac users may have difficulty seeing the Garmin device as a drive. Workarounds:

- **OpenMTP** — A free, open-source Android/MTP file transfer app for Mac that also works with Garmin devices. However, OpenMTP has **known issues with updating watch faces**: if you send an updated `.prg` to a watch that already has the face installed, the update may not take effect. You may need to delete the existing face from the watch first, disconnect, then reconnect and transfer the new file.
- **MacDroid** — Another Mac file transfer app that supports MTP connections to Garmin watches. Some users report more reliable transfers with MacDroid.
- **Garmin Express** — Garmin's own desktop app can manage files on some models.
- **ConnectIQ export** (premium) — The most reliable option for Mac users. Avoids USB transfer entirely by publishing through the Garmin store.
- **USB cable check** — Make sure your cable supports data transfer (not charge-only).

**Important for Mac users:** Only copy the `.prg` file into `GARMIN/Apps`. Do **not** put the `.zip` file in the Apps folder — the watch cannot read zip archives. Unzip first, then transfer only the `.prg` file.

### How to Delete Watch Faces

- **From the watch:** Long-press the menu button → Watch Face → scroll to the face → select Remove.
- **From Garmin Express:** Open Garmin Express on your PC, go to Apps, scroll to watch faces, and delete from there.

---

## API Keys & Weather Data

### What Is the WFB API Key?

The WFB API key enables weather and location-based features on your watch face (city name, temperature, forecasts, sunrise/sunset, moon data, etc.). Without it, these fields display "Missing API key."

### How to Set Up Your API Key

1. Log in to your WFB account.
2. Go to **My Account → Profile**.
3. Find your API key (or generate one).
4. Go to the **"Send API Key"** page on the website.
5. Follow the instructions to push the key to your Garmin device.

### WFB API Key vs. OpenWeatherMap (OWM) API Key

WFB supports **two weather sources**: the built-in WFB weather service (using the WFB API key) and **OpenWeatherMap (OWM)**. These are separate keys:

- **WFB API Key** — Built into your WFB account. Provides weather, location, city name, sunrise/sunset, and moon data. Sent to the watch via the "Send API Key" page.
- **OWM API Key** — A third-party API key from [openweathermap.org](https://openweathermap.org). Some watch face designs allow users to choose between Garmin weather and OWM weather via an app property.

**Known issue:** If a watch face includes OWM weather fields (even if the user selects Garmin weather via an app property), the app may still require an OWM API key. There is currently no way to make OWM fields fully optional at runtime — if the design references OWM tokens, the key is needed. Designers who want to offer both options may need to publish two separate versions of the watch face.

### Common API Key Issues

- **"Missing API Key" on watch** — You need to send the API key to your watch via the Send API Key page. This is a separate step after building your watch face. Do not paste the key into the "download instructions" field — use the dedicated **Send API Key** page on the website.
- **"Invalid API Key"** — Regenerate your key in your profile and re-send it to the device.
- **API key not working after Garmin update** — A Garmin firmware change removed the ability to sideload settings for some models. Publishing to ConnectIQ (premium) resolves this, as users can enter the key through the ConnectIQ app settings.
- **OWM API key confusion** — If you're using OpenWeatherMap, you need a separate OWM API key from openweathermap.org. The WFB API key and the OWM API key are different things.
- **GWF settings file generator** — Some users try using the GWF settings file generator as an alternative to the Send API Key page. If this doesn't work, use the standard Send API Key method from the WFB website.
- **Weather data showing incorrectly** — Weather fields rely on the phone's Garmin Connect app being connected and synced. If Garmin's weather service is temporarily down, WFB weather fields will also be unavailable.

---

## Tokens & Data Fields

WFB provides **679+ data tokens** that you can use to display dynamic information. Browse the full list at [garmin.watchfacebuilder.com/tokens](https://garmin.watchfacebuilder.com/tokens).

### Common Token Categories

| Category | Prefix | Examples |
|---|---|---|
| Activity History | `ah` | Daily steps chart (`ah7`), calories (`ah2`), active minutes (`ah1`) |
| Activity Info | `ai` | Active minutes today (`ai1`), weekly goals (`ai3`) |
| Heart Rate | `hr` | Current HR, resting HR, HR zones |
| Weather | `w` | Temperature, conditions, forecasts, wind |
| System | `sys` | Battery level, Bluetooth status, notifications |
| Time/Date | `t`, `d` | Hours, minutes, seconds, day, month, year |
| GPS/Location | `gps` | Latitude, longitude, altitude |
| Sun/Moon | `sm` | Sunrise, sunset, moonrise, moonset, moon phase |
| Body Battery | `bb` | Current body battery, charged/drained values |

### Using Tokens in Data Fields

- Add a data field object to your canvas.
- Select the token from the dropdown, or type the token code directly.
- Use the **format** option on data fields to control how values are displayed (e.g., formatting timestamps for sunrise/sunset times).

### Token Tips

- Use `isnull` to check if a data field has a value. For example: `isnull((cp23),"--")` displays "--" when stress data is unavailable.
- For group icons with color-coded ranges, use `isnull` to set a fallback value: `isnull((cp23),999)` where 999 maps to a "no data" color (e.g., grey for off-wrist).
- `now.value()-(sm.mn0).value()` returns total seconds since midnight — useful for time-based calculations.
- The `(ds1.1)` token can be used to detect device settings like measurement units.
- **Weekly calorie totals** — The `(ah2.t)` token represents total calories for the activity history period. Place it directly in a Data Field; no special `sum()` function is needed. For an Arc Goal, use `(ah2.t)` as the data source and set your target manually.
- **PulseOx quirk** — Unlike heart rate, PulseOx `(cp35)` may never return null even when the watch is off-wrist. To detect off-wrist state for PulseOx displays, check heart rate instead: `(cp18)==null?999:(cp35)`.
- **Dive data** — Dive-specific fields (no-fly time, surface time, dive statistics) are **not currently available** as tokens. WFB is focused on general watch face data, not dive computer data fields.
- **Calories not showing** — If calorie tokens display zero or blank, ensure your Garmin device is synced and that the activity tracking is enabled in the Garmin Connect app.
- **Moon phase inaccuracy** — Some users have reported that the moon phase icon or data does not match the actual moon phase. Moon data relies on the WFB API and your device's location/time being correct. Ensure the API key is set up, the phone is synced, and the watch has accurate time and location data. Minor discrepancies (off by a day) can occur depending on when the data was last refreshed.
- **Weather forecast (multi-day)** — Displaying a multi-day weather forecast (e.g., 3-day or 5-day forecast) requires using the forecast-specific weather tokens. Each forecast day has its own set of tokens for temperature, conditions, etc. If forecast data appears blank or outdated, it may be because the Garmin Connect app hasn't synced recently or the WFB API key isn't configured. Note that forecast accuracy depends on the underlying weather service (WFB or OWM).

---

## Expressions, Visibility & Math

### Visibility Expressions

You can show/hide objects based on conditions. This is one of the most powerful features of WFB.

**Important limitation:** Text objects only support **high/low power mode** as visibility expressions. For conditional text, use **custom bitmap fonts with math objects** instead.

**Common examples:**
- Battery warning icon visible only when battery ≤ 5%: `(icn7)<=5`
- Show different content based on device settings: `(ds1.1) == 1`
- DND/sleep mode detection: Use `(sm5.1) == "Dusk"` or similar tokens

**Common pitfalls:**
- The `!=` (not equal) operator may not work as expected in some contexts. Try using `!((expression).equal("value"))` instead.
- When using `(prop.text_1).equal("xxxx")` for app property visibility, note that complex expressions can cause compilation errors.
- **Overlapping touch responses** — This is a frequently reported issue. When multiple data fields with touch responses (press & hold shortcuts) are stacked on top of each other, the touch event may trigger the wrong app or shortcut. The topmost layer captures the touch, even if visibility expressions hide it. Workaround: avoid overlapping touch-responsive fields, or use a single transparent circle/shape on top as the sole touch target, linked to a `(prop.a1)` complication property.
- **Combining touch response with `prop.select` items** — If you have menu items controlled by `(prop.select_4)==0` through `(prop.select_4)==19` and want to add a touch response, creating a separate complication property `(prop.a1)` will result in two separate items appearing in the ConnectIQ settings menu. Currently, there is no built-in way to merge a select property and a complication touch target into a single menu item.

### Math Expressions

Use math expressions to transform data values:
- **Unit conversion:** Convert km/m to miles/ft, Celsius to Fahrenheit, etc. using math expressions.
- **Time calculations:** Calculate time differences, seconds since midnight, countdowns.
- **Conditional display:** Combine `isnull` checks with math to handle missing data gracefully.

---

## Custom Fonts & Bitmap Fonts (BMF)

### Why Use Custom Bitmap Fonts?

- Standard fonts may not look sharp on low-resolution displays (especially Instinct series at 176 × 176).
- Custom BMFs allow pixel-perfect rendering.
- BMFs can include custom icons and symbols as "characters."
- They enable conditional text display (since text objects have limited visibility support).

### Creating Bitmap Fonts

1. Use the **BMF for Garmin** tool (v2.1.1) on the WFB website.
2. Design each character at the exact pixel size you need.
3. After generating, click **Edit** on each character row to adjust X offset and Y advance values.
4. Make sure glyphs stay inside the red bounding box (italic fonts often get cut off if they extend outside it).

### Font Troubleshooting

- **Square blocks appearing** — This happens when a character is not supported by the font being used. For example, a dash, space, or comma may be missing from your custom font.
- **Blurry text on MIP displays** (Instinct, Forerunner 955) — Use bitmap fonts instead of vector fonts. Anti-aliasing cannot be disabled for vector fonts, causing a dithered/blurry look on MIP screens.
- **Font size mismatch after generating** — When creating BMF fonts, the generated size may be smaller than what you specified. For example, setting size 80 may produce a font at size 62, and size 100 may produce size 79. This is because the BMF tool adjusts for the actual glyph bounding boxes. You may need to set a larger size than intended and fine-tune by trial and error.
- **Icons shrinking when editing** — A known issue where shapes/icons resize unexpectedly. Save frequently and check dimensions after edits.
- **Finding fonts by name** — If you're looking for a specific font, browse the BMF tool's font list or check the WFB community for shared custom fonts. The font name displayed in the editor may differ from the system font name.

---

## Images, Icons & Animations

### Using Images

- Upload PNG images to use as backgrounds, icons, or decorative elements.
- Check **"Layer Object"** to allow an image to appear on top of other objects.
- Image quality can degrade on lower-resolution devices — design at the exact target resolution.

### Animated GIFs

- WFB supports animated GIFs on compatible devices with AMOLED displays.
- **GIFs stop animating when the display enters low-power mode.** This is a Garmin limitation, not a WFB issue.
- Using stacks with GIFs — the image will appear frozen in low-power mode.

### Gradient Images

You can use gradient images behind objects for visual effects. Set the foreground object's color to transparent to let the gradient show through.

**Known issue:** Gradient images may display correctly in the WFB editor but appear **on top of** other objects on the actual watch, making those objects invisible or hidden behind the gradient. Even if the layer order looks correct in the editor, the watch may render them differently. Workarounds include: ensuring "Layer Object" is checked on the correct items, rearranging the layer order in the panel, and testing on the actual device (not just the editor preview).

### Weather Icons

WFB includes built-in weather condition icons. Common questions:

- **Icon too faint/thin** — The default weather icon stroke width cannot be adjusted directly. As a workaround, you can use custom icon images instead of the built-in ones, or place a colored background behind the icon to increase contrast.
- **Changing icon color** — Weather icon colors can be changed in the object properties. If the icon is hard to see, try setting a contrasting background color or using a white/light-colored icon on a dark face.

---

## App Properties & Custom User Settings

App Properties are user-configurable settings that appear in the Garmin Connect IQ app on the user's phone. They allow each user to personalize a watch face without editing the design itself.

### Types of App Properties

- **Select/Dropdown** — Let users choose from a list of options (e.g., data field to display, color theme, weather source).
- **Number** — Let users enter a numeric value (e.g., GMT offset for a second timezone, calorie goal).
- **Text** — Let users enter custom text (e.g., their name, a custom label). This is how you create a "custom text input field" — add a text-type app property and display it using the corresponding `(prop.text_X)` token.
- **Boolean** — A toggle on/off (e.g., show/hide an element).
- **Complication** — Special properties like `(prop.a1)` that link to touch-response shortcuts, allowing users to choose which app opens when they tap an area.

### Important Notes on App Properties

- **App Properties only work when published to ConnectIQ** (premium required). Sideloaded `.prg` files cannot display on-device settings menus. This is the #1 reason to consider premium if your design uses user-configurable options.
- To create a custom text field that displays a user's name: add a text-type app property, then place a text or data field on the canvas using the `(prop.text_1)` token.
- Use `(prop.select_X)==N` in visibility expressions to show/hide objects based on the user's dropdown selection.

---

## Language & Localization

WFB supports multiple languages for day names, month names, and other localized text.

### How Language Tokens Work

WFB uses language tokens for day and month names. These tokens automatically display in the device's system language — **if** the watch face includes the correct localized strings.

| Token | Meaning | Example (English) | Example (Czech) |
|---|---|---|---|
| `wk1`–`wk7` | Short day names (Sun–Sat) | Sun, Mon, Tue... | Ned, Pon, Úte... |
| `wkf1`–`wkf7` | Full day names | Sunday, Monday... | Neděle, Pondělí... |
| `mo1`–`mo12` | Short month names | Jan, Feb, Mar... | Led, Úno, Bře... |
| `mof1`–`mof12` | Full month names | January, February... | Leden, Únor, Březen... |

### Capitalizing Day/Month Names

A common question: "How do I capitalize weekday text (e.g., MON, TUE, WED)?" — Currently, text token output follows the format defined in the language strings. If the localization provides "Mon" but you want "MON", you may need to define the strings as uppercase in the language settings, or use a bitmap font approach where uppercase and lowercase are mapped to your preferred display format.

### Adding or Fixing Language Support

- The developer (u/joshuahxh-1) can add or correct language translations. If your language has incorrect or missing translations, post a request on r/watchfacebuilder with the full list of corrected strings (using the `wk`, `wkf`, `mo`, `mof` token format shown above).
- **Restoring factory language settings** — If an older watch face was created before your language was supported, you may need to request that the developer add a "factory language reset" feature or re-export the face with updated language strings.
- Language updates to existing watch faces require a new build and re-upload to ConnectIQ.

---

## Battery Life Optimization

Battery life is a major concern for Garmin users. Watch face complexity directly impacts battery drain. Note that Garmin's built-in watch faces are written natively without the SDK, so third-party watch faces (including WFB-generated ones) will always use slightly more battery than native faces.

### How Screen Updates Work

During high-power mode the screen updates every second; in low-power mode it updates every minute. Each update involves three steps: (1) computing data values from sensors, (2) drawing objects to the screen buffer, and (3) physically updating pixels. On **MIP screens**, step 3 only uses battery when a pixel actually changes value. On **AMOLED screens** (Epix, Venu), step 3 uses battery whenever a pixel is lit. This is why dark backgrounds save more battery on AMOLED.

Same data fields are not calculated multiple times, but formatting the same value differently and outputting it to multiple locations will consume more battery.

### Update Intervals

Many objects have an **Update interval** setting. The global update interval defines how often the screen refreshes (default is 1 second in high-power mode). Increasing this can dramatically reduce battery drain:

- Setting the global update interval to **15 seconds** reduced HighPower Time from 47,485 μs to 36 μs in simulator testing.
- However, a higher interval affects everything — including how often the clock seconds update, notification icons refresh, etc.
- Individual objects can override the global interval with their own custom interval.

The **Communication interval** controls how often the watch communicates with the internet (via phone or Wi-Fi). This only applies when using data fields that require internet data (OWM weather, WFB API, Dexcom, auth). OWM data updates every 30 minutes (5 minutes if you've moved more than 1 km). Increase this interval if you don't need frequent weather updates.

### Static vs. Dynamic Objects

All static objects are merged into one background image and drawn at the start of each update. If you have many small static objects scattered across the screen, the merged image becomes large and takes longer to load. Counterintuitively, converting static objects to **dynamic objects** can save battery in this case, because dynamic objects are drawn individually and may be more efficient when spread across the screen. Use the **Visibility** setting to hide objects that aren't needed — hidden objects now save battery (this was improved in a recent WFB update).

### Curved Text and Arcs

Curved text can have a **major impact on memory consumption and file size**. For example, an IQ file can jump from 4 MB to 9 MB with unoptimized curved text. To optimize: add a custom font containing only the characters you need, and consider using custom images instead of arc/circle objects when possible.

### Tips to Minimize Battery Impact

- **Reduce the number of data fields** — Each active data field uses processing power.
- **Avoid per-second updates** — Showing seconds (especially on MIP displays) significantly increases battery drain. Use per-minute updates where possible. Consider increasing the global update interval.
- **Use sensor history data** instead of live sensor data when possible — live data consumes more battery.
- **Limit weather/API calls** — Increase the communication interval if you don't need frequent updates.
- **Use simpler graphics** — Fewer images and animations = less battery usage.
- **Minimize use of always-on elements** — Use high/low power mode visibility to hide non-essential elements when the screen is dimmed.
- **Overlapping objects** are generally fine — having layered objects on top of each other shouldn't significantly impact battery.
- **Test on your actual device** — Battery impact varies significantly between AMOLED (Epix, Venu) and MIP (Forerunner, Instinct, Fenix) displays. Simulator results are indicative but not exact.

### Calculating Battery Drain Rate

You can display a live battery drain rate on your watch face using a math expression:

`((ds3.4)-(ds3)).toFloat()/(now.value()-(ds3.5).value())*300`

Use format `-%.4f%` to show up to 4 decimal places. This shows battery drain for the last 5 minutes (replace `*300` with a different multiplier for other time windows). Note: it may require at least 1% charge and some time before values appear.

---

## Memory Optimization

Memory limits vary by Garmin device and can cause "Out of Memory" (OOM) crashes if exceeded. OOM errors are most commonly caused by images or static objects.

### Finding Your Device's Memory Limit

To check how much memory your watch allows for watch faces:
1. Visit the [Garmin developer device reference](https://developer.garmin.com/connect-iq/compatible-devices/).
2. Click your watch name → App Types → Memory Limit → "Watch Face."
3. The size is listed in bytes — divide by 1024 for KB.

### Debugging OOM Issues

- Add two **"free memory"** data fields to your watch face: one in front of your image/object layer and one after it. The difference shows how much memory that layer consumes.
- Check crash logs on the watch at `/GARMIN/APPS/LOGS/CIQ_LOG.YML` for detailed error info.
- Remove images one by one to isolate the culprit — images and static objects are the most common cause of OOM.

### How Image Memory Works

When drawing an image, the system loads it from storage into memory, draws it, then releases the memory before handling the next object. The bigger the image (width × height), the more memory is needed during this loading phase — even temporarily. This means a single large background image can spike memory usage even if the final drawn result is efficient.

### Memory Optimization Tips

- **Static objects are merged into one background image** at compile time. If that merged image is very large, it takes more memory to load but uses less battery. Converting some static objects to **layer (dynamic) objects** can reduce peak memory usage at the cost of slightly more battery.
- **Use math expressions for static text** instead of text objects — text objects consume more memory.
- **Use SVG for clock hands.** Each non-SVG hand generates 60 separate images (one per position), which consumes significant memory and increases file size. SVG hands are rendered dynamically and are far more memory-efficient.
- **Curved text** can dramatically increase memory usage and file size. Use a custom font with only the characters you need, or replace curved text with a pre-rendered image.
- **Reduce image dimensions** — resize images to the exact pixel size needed rather than scaling down large images on the watch.
- **Data fields** usually don't take much memory unless they include charts. The biggest memory consumers are typically static objects like background images, horizon lines, and icons.

---

## Publishing to Garmin Connect IQ

### Exporting to ConnectIQ (Premium Required)

1. Build your watch face in the Builder.
2. Click the **Export to ConnectIQ** option.
3. This generates a `.iq` file instead of a `.prg` file.
4. Go to [apps.garmin.com/developer/dashboard](https://apps.garmin.com/developer/dashboard).
5. Create a developer account if you don't have one.
6. Upload the `.iq` file and configure your listing.
7. Submit as **beta** (for personal testing/sharing) or **public** (for the store).

### Why Publish to ConnectIQ?

- **App Properties work properly** — Users can configure settings (colors, data fields, etc.) through the Garmin Connect app on their phone.
- **Easier installation** — Users install directly from the store, no USB cable needed.
- **Updates** — You can push updates to users who installed your face.
- **Wider audience** — Share your designs with the Garmin community.

### Versioning Tips

During frequent beta testing, consider using a simple incrementing version number (1, 2, 3, ...) rather than semantic versioning (1.0.1, 1.0.2). It's quicker and avoids confusion during rapid iteration. You can switch to a proper versioning scheme for public releases.

### EEA Region Requirements

If you want to release your watch face in the **EEA region** (European Economic Area — several countries in Europe and Asia), you must apply for developer request verification and ensure your app description lists all permissions your watch face uses. You can see the required permissions in the ConnectIQ store listing or within the app itself.

### Common ConnectIQ Issues

- **Export stuck/hanging** — If the export process seems stuck for hours, try rebuilding and re-exporting. Check your internet connection.
- **Missing objects after export** — Some elements present in the builder may not appear in the ConnectIQ version. Rebuild and verify all layers are included.
- **Beta install via Developer Dashboard** — Some users have reported difficulty installing beta watch faces since late 2025. If the dashboard doesn't sync new devices, try using the Garmin Connect mobile app instead.
- **Update not showing up** — During beta testing, updates can take a long time to appear. On Android, force-closing the Connect IQ app and reopening it usually makes the update appear immediately. If that doesn't work, try re-uploading the same version with an incremented version number.
- **Wrong version number displayed** — The Connect IQ app frequently shows the previous version number even after an update is applied. The watch will have the correct content — the app display fixes itself after some time (sometimes after a force close).
- **Watch face crashes during testing** — Reboot the watch during heavy testing phases, especially after installing broken or incomplete watch faces.

---

## Premium Membership

### What's Included

- **Ad-free experience** in the Builder
- **Export to ConnectIQ** (`.iq` files)
- **Automated testing** in the Garmin Simulator
- **Timeline** — Every time you build, WFB automatically saves the current state, creating a version history you can roll back to
- **Weather data via WFB API** for premium members

### How to Subscribe

1. Log in and go to **My Account → Profile**.
2. Scroll to the Membership section.
3. Click **Subscribe** to access the subscription page.
4. New subscribers get a **30-day free trial**.
5. **PayPal** and credit card payments are accepted.

### "Can't Save Without Premium" Confusion

Some users mistakenly believe they need premium to save or download their watch face. **This is not the case.** Saving your design and downloading the `.prg` file are both free features. What premium unlocks is the ability to export a `.iq` file for the ConnectIQ store, automated simulator testing, and an ad-free experience. If you're having trouble saving or downloading, check that you're logged in and look for the download button below the watch face preview after building.

### Is Premium Worth It?

The free tier covers all core design and build features. Premium is particularly valuable if you:
- Want to publish to the ConnectIQ store
- Need app properties to work (user-configurable settings)
- Want to test in the Garmin simulator before installing
- Prefer an ad-free editing environment

---

## Troubleshooting Common Errors

### "IQ!" Error on Watch

This appears when a watch face crashes on the device. Common causes:
- **Wrong device model** — The `.prg` file was built for a different device than your watch. This is the most common cause. For example, a `.prg` built for Fenix 7 will show "IQ!" on a Fenix 8.
- A compile error exists in the design (check for conflicting expressions).
- Stack overflow — usually caused by overly complex visibility expressions.
- Corrupt `.prg` file — try regenerating and re-downloading.

**Fix:** Rebuild with the **exact correct device** selected. If you have a Fenix 8, select Fenix 8 specifically — don't assume a different Fenix model will work. Simplify complex expressions if the error persists.

### Compilation Errors

- **"Compile errors for item on topmost layer"** — Often caused by conflicting object configurations. Try reordering layers or removing and re-adding the problematic object.
- **Errors with `(prop.text_1).equal()`** — Complex property expressions can cause compilation failures. Simplify or restructure your conditional logic.

### Stack Overflow

If your watch face causes a stack overflow error, the most common cause is overly complex visibility expressions. For example, changing `(ds1.1) == 1` to a more complex chain of conditions can exceed the device's stack limit. Simplify your expressions or split them across multiple objects.

### Watch Face Showing Up Blank After Installing

This is reported frequently, especially by Vivoactive 5 and Mac users:
- **Transferred the `.zip` instead of the `.prg`** — You must unzip the download first and copy only the `.prg` file to `GARMIN/Apps`. The watch cannot read `.zip` files.
- **Wrong device model** — If the `.prg` was built for a different device, the face may appear blank or show "IQ!".
- **Mac transfer issues** — If using OpenMTP or MacDroid, ensure the file transferred completely. Try deleting the existing face from the watch, disconnecting, reconnecting, and transferring again.
- **Verify in the Builder** — Open the design in WFB and use the preview/simulator to confirm it displays correctly before re-downloading.

### Watch Face Not Displaying Properly

- Verify you selected the correct device model in the Builder.
- Check that all objects fit within the screen dimensions.
- Ensure fonts support all characters you're trying to display (missing characters appear as square blocks).

### "PRG File Disappeared"

After a Garmin firmware update, `.prg` files may appear to vanish from the `GARMIN/Apps` folder. The files are moved internally by the watch OS. Long-press the menu button, go to Watch Face, and scroll — your face should still be there.

### Seconds Showing Square Blocks (MIP Displays)

On MIP displays (Forerunner 955, Instinct, Fenix), showing seconds may cause rendering issues. The per-second update can sometimes display a square block instead of the digit. Use bitmap fonts for more reliable second-by-second rendering on MIP screens.

### Location Data Lost / Sunrise-Sunset Off

Some users report that location-based data (sunrise/sunset times) occasionally show incorrect values. This happens when the watch loses its GPS fix. Ensure your phone's Garmin Connect app is synced and that the watch has had a recent GPS lock.

---

## Known Limitations & Quirks

### What WFB Can and Cannot Build

WFB is specifically a **watch face** builder. It does not currently support building other ConnectIQ app types such as data fields, widgets, glances, or full apps. This has been requested by the community but is not yet available. Community members have also requested features like HTTP/REST API calls from watch faces and on-watch keyboard entry fields — these are not currently possible due to ConnectIQ platform limitations.

### Copy/Paste Between Watch Faces

Copying objects between two different watch face designs is a supported feature, but users have reported a bug where copy works (you see "selected object(s) copied to clipboard") but pasting into a different watch face shows "no object selected" and nothing happens. If you encounter this, try: refreshing both editor tabs, ensuring you're using the same editor version (legacy or new) for both, or as a workaround, manually recreate the objects in the target design.

### PRG File Size Anomalies

Small changes to images can cause disproportionately large increases in `.prg` file size. For example, a background PNG that increases by only ~130 bytes can result in a `.prg` file that grows by ~20 KB. This is because WFB re-encodes images during the build process, and factors like image color depth, palette changes, and compression can amplify small source changes. If file size matters (some older devices have tight limits), experiment with different image optimizations before building.

### Global Variables & Arrays

WFB supports global variables including arrays. You can define an array and use the current second (or other token) as an index to look up values — for example, positioning a dynamic image at different X coordinates each second. However, the syntax can be tricky and not all array operations work as expected. If a math expression referencing an array doesn't work, try simplifying the expression or breaking it into multiple steps.

### Timer Complication

Displaying a running timer countdown on the watch face (like a complication showing time remaining) is **not currently supported** in WFB. This is a frequently requested feature. While some stock Garmin watch faces now include timer complications, the ConnectIQ API access needed for this may not yet be available to WFB.

### CIQ SDK Version for PRG Files

Some users have asked whether they can select which ConnectIQ SDK version is used when generating a `.prg` file. Currently, WFB uses a fixed SDK version for compilation. You cannot manually choose the SDK version. If your device requires a newer SDK (e.g., for newer Garmin models), WFB typically stays updated, but if you encounter compatibility issues with a very new device, check r/watchfacebuilder for announcements about SDK updates.

### Updating a Running Watch Face

When you update a watch face design and re-download the `.prg` file, you need to transfer the new file to the watch to see the changes. However, there are known issues with this process:

- **Via USB (Windows):** Copy the new `.prg` to `GARMIN/Apps`, overwriting the old one. Disconnect and the watch should load the updated version.
- **Via OpenMTP (Mac):** OpenMTP has a known issue where sending an updated `.prg` to a watch that already has the face installed may not apply the update. You may need to: delete the existing watch face from the watch first, disconnect, reconnect, then transfer the new `.prg`.
- **Via ConnectIQ (Premium):** Upload the new `.iq` file to the developer dashboard and push an update. Users who installed from the store will receive the update automatically.

### Condition Text Returns Are Not Strings

Some users have encountered issues where the condition/text return value from an expression is treated as a non-string type, causing unexpected display behavior. If you're using expressions to output text conditionally, ensure the return values are explicitly formatted as strings. Wrapping values in quotes within the expression or using string-specific tokens can help avoid type mismatch issues.

### Features Only Available on ConnectIQ (Premium)

Some features require publishing to the ConnectIQ store (premium):
- App Properties (user settings on phone)
- API key configuration via ConnectIQ settings
- OTA updates for users who installed your face
- Wider device compatibility testing via simulator

---

## MIP Display Issues

MIP (Memory-in-Pixel) displays — found on the Instinct series, Forerunner 255/955, and Fenix line — behave very differently from AMOLED screens. Several community-reported issues are specific to MIP devices.

### Washed-Out or Grainy Graphics

Images that look crisp on AMOLED (Epix, Venu) can appear washed out, grainy, or dithered on MIP screens. This is because MIP displays have a limited color palette — the screen physically cannot render smooth gradients or anti-aliased edges the way AMOLED can. Workarounds include: designing images with flat/solid colors and high contrast, avoiding subtle gradients, using bitmap fonts instead of vector fonts, and testing on the actual MIP device rather than relying on the editor preview.

### AOD (Always-On Display) Pixel Estimation

Some users have reported discrepancies with the estimated AOD (Always-On Display) pixel count shown in the builder versus the actual result on-device. The pixel budget is a Garmin-enforced limit that restricts how many pixels can be lit in always-on/low-power mode to save battery. If your design exceeds this limit, it may be automatically simplified or hidden in low-power mode. Reduce the number of visible elements in low-power mode and use high/low power visibility settings to control what appears.

### Scrolling Text Issues

The scroll/marquee text feature may not work reliably on all MIP devices. Some users have reported that scroll text appears frozen or does not animate as expected. This can be related to the per-minute update cycle on MIP displays — scrolling text requires more frequent screen refreshes, which MIP screens handle differently from AMOLED. If scroll text is not working, consider using a shorter static text label or a bitmap font approach instead.

---

## Tips & Advanced Techniques

### Displaying a Second Timezone

To show a second timezone adjustable by the user:
- Create an app property (number) for the GMT offset.
- Use a math expression to add/subtract the offset from the current time tokens.
- Publish to ConnectIQ so users can set the offset in app settings.

### Calendar/Week View

To display calendar days on your watch face:
- Use math expressions to calculate the first day of the current week.
- Display 7 days per row across 4 rows for a 28-day view.
- Use tokens like ISO week number and day-of-year for advanced date calculations.

### Showing Day Names (Mon, Tue, Wed...)

Since text objects have limited visibility support, use custom bitmap fonts where each "character" represents a day name. Map day-of-week numbers to the corresponding font characters.

### Selectable/Customizable Data Fields

For watch faces published to ConnectIQ, use **app properties** to let users choose which data to display. Create property dropdowns and use visibility expressions to show/hide the appropriate data field objects.

### Tide Predictions

WFB includes tide prediction tokens. Note that accuracy depends on your location data being current. If tide values seem wrong, ensure the watch has a recent GPS fix and the phone app is synced.

### Analog Clock Hands

- Use rotation objects for hour, minute, and second hands.
- To snap the hour hand to exact hour positions (every 30 degrees), use a floor function in a math expression.

### Dynamic Lines and Shapes

- Dynamic lines can be tricky — editing one property (like length) may corrupt other properties (like Y position). Edit values carefully and save frequently.
- Use the layer system to control which objects appear on top.

### Letting Users Choose Their Weather Source

You can use an app property (select/dropdown) to let users choose between Garmin weather and OpenWeatherMap. Use visibility expressions tied to the property value to show/hide the appropriate weather data fields. Note the OWM API key limitation described in the API Keys section above.

### Heart Rate & Battery Savings

Different heart rate tokens have different battery impacts. Using a simple current HR display updates less frequently than a continuous HR graph. If battery life is critical, use the least resource-intensive HR token for your needs and avoid per-second HR updates.

### Using `isnull` Effectively

The `isnull` function is essential for handling missing data gracefully. Common patterns:
- **Data field fallback:** `isnull((cp23),"--")` — show "--" when no data
- **Icon color coding:** `isnull((cp23),999)` — use 999 as a "no data" sentinel in group icons
- **Off-wrist detection via HR:** `(cp18)==null?999:(cp35)` — check HR to determine if PulseOx data is valid
- Always test isnull behavior on your actual device, as some tokens (like PulseOx) behave differently than expected regarding null states.

---

## Privacy & Data Policy

A common concern for new users is how WFB handles personal data. The WFB team has addressed this directly on the subreddit:

- **WFB does not collect or store personal health data** from your Garmin device. All health metrics (heart rate, steps, stress, etc.) are processed locally on the watch by the generated app.
- **The WFB API key** is used solely for fetching weather and location data. It does not transmit health, activity, or personal information.
- **Watch face designs** saved to your WFB account are stored on WFB servers. You can set your designs as private or public (cloneable).
- If you have specific privacy concerns, post them on r/watchfacebuilder — the developer has been transparent about data practices.

---

## Keyboard & Mouse Shortcuts

The WFB Builder supports several keyboard and mouse shortcuts to speed up design work. These were documented in a pinned post by the moderators:

- **Arrow keys** — Nudge selected object by 1 pixel
- **Delete/Backspace** — Delete selected object
- **Ctrl+C / Ctrl+V** — Copy/paste objects (also works between watch faces, though a bug may prevent cross-face paste — see Known Limitations)
- **Mouse wheel** — Zoom in/out on the canvas
- **Click + drag** — Move objects on the canvas
- Check the pinned post on r/watchfacebuilder titled "WFB Builder Keyboard/Mouse shortcut" for the complete and most up-to-date list.

---

## Community Resources

- **Watchface Tutorial** (pinned post) — A step-by-step video/guide pinned on r/watchfacebuilder for new users getting started with the builder.
- **How to Remove Sideloaded PRG Files** (pinned post) — Instructions on r/watchfacebuilder for properly removing watch faces installed via USB.
- **Apps in ConnectIQ Store Created by WFB** (pinned post) — A curated list of watch faces on the Garmin store that were built using WFB, useful for inspiration.
- **Unofficial Community Wiki (Gitea):** [code.binbash.rocks — WFB Wiki](https://code.binbash.rocks:8443/GarminWatch/watchfacebuilder/wiki) — Detailed community-maintained documentation covering battery optimization, memory optimization, useful functions, ConnectIQ publishing tips, and FAQ.
- **Official Help Guide:** [garmin.watchfacebuilder.com/garmin-device-app-online-builder-help](https://garmin.watchfacebuilder.com/garmin-device-app-online-builder-help/)
- **Website:** [garmin.watchfacebuilder.com](https://garmin.watchfacebuilder.com)
- **Reddit:** [r/watchfacebuilder](https://www.reddit.com/r/watchfacebuilder)
- **Token Reference:** [garmin.watchfacebuilder.com/tokens](https://garmin.watchfacebuilder.com/tokens)
- **BMF Font Tool:** [BMF for Garmin](https://garmin.watchfacebuilder.com) (accessible from the top menu)
- **Garmin Developer Dashboard:** [apps.garmin.com/developer/dashboard](https://apps.garmin.com/developer/dashboard)
- **Garmin Connect IQ SDK Docs:** [developer.garmin.com](https://developer.garmin.com)
- **OpenMTP (Mac file transfer):** [openmtp.ganeshrvel.com](https://openmtp.ganeshrvel.com)
- **OpenWeatherMap (for OWM API keys):** [openweathermap.org](https://openweathermap.org)

### Community Tips for New Users

- **Clone existing designs** to learn how experienced builders structure their watch faces. This is one of the fastest ways to understand how layers, expressions, and tokens work together.
- **Start simple** — get a basic face working first, then add complexity. Don't try to build a 50-field design on your first attempt.
- **Check the Tokens page** before asking how to display a specific data point — WFB likely already supports it with 679+ tokens.
- **Post questions on r/watchfacebuilder** — the community and the developer (u/joshuahxh-1) are very active and helpful. Include your watch face link or app ID when asking for help so others can look at your design.
- **Save your work frequently** — there is no way to recover a design from a `.prg` file if you lose your project.
- **Test on your actual device** — the editor preview and the watch can render things differently, especially layer ordering, gradient images, and font rendering on MIP vs AMOLED screens.
- **Share your creations!** — The community loves seeing new designs. Posts like "Made by my son and I" and "Thank you watchfacebuilder" show the supportive nature of the community.

---

*This wiki was compiled from community discussions on r/watchfacebuilder and the official WFB website. Last updated: May 2026.*
