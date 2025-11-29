# 🎧 VR Spatial Audio Tech Demo  
**Immersive XR Experience Focused on Spatialized Audio**

This Unity project is a VR Tech Demo showcasing how **spatialized audio** can dramatically enhance immersion in virtual environments.  
While most VR titles focus solely on visuals, this prototype highlights the often underutilized power of **360° soundscapes** delivered through VR headsets.  

---

## 📌 Elevator Pitch  
Virtual reality is more than 360° visuals—it's also **360° audio**.  
This demo demonstrates how spatialized sound, terrain-aware footsteps, ambient regions, and reactive audio cues can make even a simple world feel alive.  

---

# 🗺 Project Overview

## 📝 Concept  
A VR experience designed to highlight the impact of spatial audio in open-world-like environments.

## 👥 Target Audience  
- Game developers  
- VR audio researchers  
- Enthusiasts exploring immersive audio design  

## 🧭 Genre & Setting  
- **Genre:** Immersive VR Experience  
- **Setting:** Natural landscapes (forest, desert, snow mountains, rivers)  
- **World:** Open, free-roam environment  

## 🕹 Player  
Standard XR Origin rig using generic VR controllers.  

---

# 🔊 Core Features

## 🔉 1. Advanced Spatial Audio System  
Uses the **Meta XR Audio SDK** to spatialize all audio sources via the `SpatializerMixer`.  
Includes realistic **distance-based volume rolloff** to emulate real-world sound attenuation.  

---

## 👣 2. Terrain-Specific Footstep System  
As the player walks, the system:

1. Detects the **terrain texture** under the player  
2. Matches it with a **FootstepCollection** (ScriptableObject)  
3. Plays a random footstep sound for that terrain  
4. Handles **jump** and **landing** sounds  
5. Outputs sounds spatially from **beneath the player**  

Multiple clips per terrain type create natural variation.  

### Supported Terrain Types  
- Dirt  
- Grass (multiple variations)  
- Sand  
- Snow  
- Water  

---

## 🌲 3. Zone-Specific Ambient Audio  

The world contains 4 distinct sound regions:  

| Zone | Ambient Audio |
|------|---------------|
| **Forest** | Birds, wind in trees |
| **Desert** | Sandstorm ambience |
| **Snow Mountain** | Strong winds, snowfall |
| **Water Bodies** | Flowing water currents |

All ambient audio is spatialized and distance-attenuated.

---

## 🪨 4. Terrain-Aware Interaction Audio  
Players can pick up small rocks and throw them.  
On impact, the system detects the **terrain type** and plays the appropriate landing audio.  
---

## 🏹 5. Bow & Arrow VR Interaction  
- Fully interactable bow  
- Pull, tension, release  
- Spatialized bowstring pluck  
- Spatialized arrow impact  

---

# 🎮 Gameplay & Mechanics

## 🚶 Character Movement  
Controlled via VR controllers:  
- Left stick → locomotion  
- Right stick → rotation  
- “B” button → jump  
- Movement direction follows head orientation  

Enables smooth free-axis navigation of the whole environment.

---

# 🎨 World & Atmosphere

## 🌿 Look & Feel  
A calm VR stroll through nature designed primarily as a **canvas for audio immersion**.  

## 📍 Locations  
Each zone features:  
- Distinct ambient audio  
- Unique footstep sets  
- Terrain-based physics audio  
- Natural environmental sounds
  
---

# 📦 Assets Included  
As described in the GDD:  

- Bow system  
- Arrow mechanics  
- XR Origin setup  
- Unity Terrain system  

---

# ⚙️ Technical Highlights
- ✔ Meta XR Audio SDK (SpatializerMixer)  
- ✔ ScriptableObject-driven footstep data  
- ✔ Runtime alphamap terrain sampling  
- ✔ Randomized non-repeating audio playback  
- ✔ Dynamic footstep swapping  
- ✔ VR interaction systems (pickup, throwing, bow)  
- ✔ Spatialized ambience and collisions  

---

# 📘 License  
MIT

---

# 🙌 Credits  
Developed by **Aleksandar Bankov**

