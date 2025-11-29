# 🎧 VR Spatial Audio Tech Demo  
**Immersive XR Experience Focused on Spatialized Audio**

This Unity project is a VR Tech Demo showcasing how **spatialized audio** can dramatically enhance immersion in virtual environments.  
While most VR titles focus solely on visuals, this prototype highlights the often underutilized power of **360° soundscapes** delivered through VR headsets.  
:contentReference[oaicite:0]{index=0}

---

## 📌 Elevator Pitch  
Virtual reality is more than 360° visuals—it's also **360° audio**.  
This demo demonstrates how spatialized sound, terrain-aware footsteps, ambient regions, and reactive audio cues can make even a simple world feel alive.  
:contentReference[oaicite:1]{index=1}

---

# 🗺 Project Overview

## 📝 Concept  
A VR experience designed to highlight the impact of spatial audio in open-world-like environments.  
:contentReference[oaicite:2]{index=2}

## 👥 Target Audience  
- Game developers  
- VR audio researchers  
- Enthusiasts exploring immersive audio design  
:contentReference[oaicite:3]{index=3}

## 🧭 Genre & Setting  
- **Genre:** Immersive VR Experience  
- **Setting:** Natural landscapes (forest, desert, snow mountains, rivers)  
- **World:** Open, free-roam environment  
:contentReference[oaicite:4]{index=4}

## 🕹 Player  
Standard XR Origin rig using generic VR controllers.  
:contentReference[oaicite:5]{index=5}

---

# 🔊 Core Features

## 🔉 1. Advanced Spatial Audio System  
Uses the **Meta XR Audio SDK** to spatialize all audio sources via the `SpatializerMixer`.  
Includes realistic **distance-based volume rolloff** to emulate real-world sound attenuation.  
:contentReference[oaicite:6]{index=6}

---

## 👣 2. Terrain-Specific Footstep System  
As the player walks, the system:

1. Detects the **terrain texture** under the player  
2. Matches it with a **FootstepCollection** (ScriptableObject)  
3. Plays a random footstep sound for that terrain  
4. Handles **jump** and **landing** sounds  
5. Outputs sounds spatially from **beneath the player**  

Multiple clips per terrain type create natural variation.  
:contentReference[oaicite:7]{index=7}

### Supported Terrain Types  
- Dirt  
- Grass (multiple variations)  
- Sand  
- Snow  
- Water  

---

## 🌲 3. Zone-Specific Ambient Audio  

The world contains 4 distinct sound regions:  
:contentReference[oaicite:8]{index=8}

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
:contentReference[oaicite:9]{index=9}

---

## 🏹 5. Bow & Arrow VR Interaction  
- Fully interactable bow  
- Pull, tension, release  
- Spatialized bowstring pluck  
- Spatialized arrow impact  
:contentReference[oaicite:10]{index=10}

---

# 🎮 Gameplay & Mechanics

## 🚶 Character Movement  
Controlled via VR controllers:  
- Left stick → locomotion  
- Right stick → rotation  
- “B” button → jump  
- Movement direction follows head orientation  
:contentReference[oaicite:11]{index=11}

Enables smooth free-axis navigation of the whole environment.

---

# 🎨 World & Atmosphere

## 🌿 Look & Feel  
A calm VR stroll through nature designed primarily as a **canvas for audio immersion**.  
:contentReference[oaicite:12]{index=12}

## 📍 Locations  
Each zone features:  
- Distinct ambient audio  
- Unique footstep sets  
- Terrain-based physics audio  
- Natural environmental sounds  
:contentReference[oaicite:13]{index=13}

---

# 📦 Assets Included  
As described in the GDD:  
:contentReference[oaicite:14]{index=14}
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

