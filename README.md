# RPG Shop Sample, by Murilo Dias Moraes

This sample was created in 48 hours.

I developed this little shop game mechanic where the player can walk up, down, left, and right using WASD, interact with NPCs using E, and open the player inventory using I.

## Project Structure

### Folders:
- **Assets:**
  - **Animation:** Contains all animation clips and animators.
  - **Brackeys:** Brackeys 2D Mega Pack assets.
  - **Editor:** Editor scripts (only one script used to play the game through the editor in scene 0).
  - **Prefabs:** All non-resource prefabs used in the project.
  - **Resources:** ScriptableObjects and prefabs loaded at runtime.
  - **Scenes:** Project scenes (EntryPoint for configuration GameObjects and Singletons, CreateCharScene shown only in the first playthrough, ShopScene where the main game happens).
- **Scripts:** All project code files, organized by feature:
  - Common
  - EventSystem
  - Inventory
  - NPCs
  - Player
  - ShopUI
- **Settings:** Unity URP configuration files and assets.
- **TextMesh Pro:** Text plugin used in the project.
- **Textures:** Sprites and sprite atlases, including external asset plugins for 2D assets.

## Key Features

### Player Character:
- 2D sprite with basic movement controls.
- Known issue: Uses Unity InputSystem for key presses, making it potentially difficult to port to other platforms in the future. Update may be required.

### Paper Doll System:
- Allows equipping and unequipping items.

### NPC Interaction:
- **Shopkeeper NPC:** Enables player to purchase and sell items that are equipped.
- **Tip Dragon NPC:** Provides useful gameplay tips.

## External Assets
- Art and font assets used:
  - [2D Mega Pack by Brackeys](https://assetstore.unity.com/packages/2d/free-2d-mega-pack-177430)
  - [Character Base by Seliel the Shaper](https://seliel-the-shaper.itch.io/character-base)
  - [Roguelike/RPG pack from Kenney](https://www.kenney.nl/assets/roguelike-rpg-pack)
  - Fonts: Copyduck and Good Bakwan.

