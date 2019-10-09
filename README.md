[![Nuget](https://img.shields.io/nuget/v/GmodNET.API?color=Blue&style=for-the-badge)](https://www.nuget.org/packages/GmodNET.API/)

# Gmod.NET

Cross-platform .NET Module/Plugin platform for Garry's Mod powered by __NET Core__.

## About

Gmod.NET is Garry's Mod Module/Plugin loader for C#
and other .NET languages which runs across all platforms (Windows,
Linux, MacOs). Gmod.NET allows you to develop Garry's Mod extensions without
need to close or reload your game or server.

## Current features

GmodNET provides basic functionality to write Garry's Mod modules in C# or any other CIL-compiled language as __NET Core 3.0__
class libraries. For more information on modules and API check out [project's wiki](https://github.com/GlebChili/GmodDotNet/wiki). Only `x86_64` version of Garry's Mod is currently supported.

## Building and contributing

Gmod.NET is subdivided into two subprojects. Garry's Mod binary native module is
contained in __gm_dotnet_native__ folder. It is written in __C++__ and uses
__CMake__ as its build (prebuild) system.

Managed part is an msbuild solution developed against `netcoreapp3.0` specification.

## Installation and usage

1) Download latest build from the project's [releases page](https://github.com/GlebChili/GmodDotNet/releases).

2) Unpack archive to the `%GARRYS_MOD_ROOT_FOLDER%garrysmod/lua/bin/` folder.

3) Create a `Modules` folder inside `garrysmod/lua/bin/`.

4) Place your .NET module, ...deps.json file, and all dependencies in `Modules/%exact_name_of_the_module_without_dll/` folder.

5) Start the game and type `lua_run require("dotnet")` in console (type `lua_run require("dotnet")` to load GmodNET client-side)

6) Use `gmod_net_load_all` (`gmod_net_load_all_cl` for client-side) console command to load all managed modules and `gmod_net_unload_all` (`gmod_net_unload_all_cl`) to unload them. Modules can be hot-reloaded, so one doesn't need to quit game to see changes. 

## License

Whole project is licensed under MIT License.
