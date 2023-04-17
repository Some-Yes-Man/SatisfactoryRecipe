namespace GetSatisfactoryRecipe {
    internal class Program {

        private static readonly Material materialIronOre = new("_Iron Ore");
        private static readonly Material materialIronIngot = new("_Iron Ingot");
        private static readonly Material materialIronRod = new("_Iron Rod");
        private static readonly Material materialIronPlate = new("_Iron Plate");
        private static readonly Material materialReinforcedIronPlate = new("_Reinforced Iron Plate");
        private static readonly Material materialScrew = new("_Screw");
        private static readonly Material materialCopperOre = new("_Copper Ore");
        private static readonly Material materialSteelIngot = new("_Steel Ingot");
        private static readonly Material materialSteelBeam = new("_Steel Beam");
        private static readonly Material materialCoal = new("_Coal");
        private static readonly Material materialPetroleumCoke = new("_Coke");
        private static readonly Material materialPolymerResin = new("_Polymer Resin");
        private static readonly Material materialWater = new("_Water");
        private static readonly Material materialCrudeOil = new("_Crude Oil");
        private static readonly Material materialHeavyOilResidue = new("_Heavy Oil Residue");
        private static readonly Material materialSulfur = new("_Sulfur");
        private static readonly Material materialCompactedCoal = new("_Compacted Coal");
        private static readonly Material materialRubber = new("_Rubber");
        private static readonly Material materialWire = new("_Wire");
        private static readonly Material materialCopperIngot = new("_Copper Ingot");
        private static readonly Material materialCateriumOre = new("_Caterium Ore");
        private static readonly Material materialCateriumIngot = new("_Caterium Ingot");
        private static readonly Material materialPlastic = new("_Plastic");
        private static readonly Material materialFuel = new("_Fuel");
        private static readonly Material materialCable = new("_Cable");
        private static readonly Material materialQuickwire = new("_Quickwire");
        private static readonly Material materialLimestone = new("_Limestone");
        private static readonly Material materialSilica = new("_Silica");
        private static readonly Material materialConcrete = new("_Concrete");
        private static readonly Material materialCopperSheet = new("_Copper Sheet");
        private static readonly Material materialModularFrame = new("_Modular Frame");
        private static readonly Material materialSteelPipe = new("_Steel Pipe");
        private static readonly Material materialRotor = new("_Rotor");
        private static readonly Material materialSmartPlating = new("_Smart Plating");
        private static readonly Material materialVersatileFramework = new("_Versatile Framework");
        private static readonly Material materialAutomatedWiring = new("_Automated Wiring");
        private static readonly Material materialEncasedIndustrialBeam = new("_Encased Industrial Beam");
        private static readonly Material materialHeavyModularFrame = new("_Heavy Modular Frame");
        private static readonly Material materialStator = new("_Stator");
        private static readonly Material materialMotor = new("_Motor");
        private static readonly Material materialHighspeedConnector = new("_High-Speed Connector");
        private static readonly Material materialCircuitBoard = new("_Circuit Board");
        private static readonly Material materialCrystalOscillator = new("_Crystal Oscillator");
        private static readonly Material materialQuartzCrystal = new("_Quartz Crystal");
        private static readonly Material materialAiLimiter = new("_AI Limiter");
        private static readonly Material materialRawQuartz = new("_Raw Quartz");

        private static readonly Recipe recipeIronOre = new Recipe("Iron Ore", 1).AddOutput(materialIronOre, 1);
        private static readonly Recipe recipeCopperOre = new Recipe("Copper Ore", 1).AddOutput(materialCopperOre, 1);
        private static readonly Recipe recipeCoal = new Recipe("Coal", 1).AddOutput(materialCoal, 1);
        private static readonly Recipe recipeWater = new Recipe("Water", 1).AddOutput(materialWater, 2);
        private static readonly Recipe recipeCrudeOil = new Recipe("Crude Oil", 1).AddOutput(materialCrudeOil, 1);
        private static readonly Recipe recipeSulfur = new Recipe("Sulfur", 1).AddOutput(materialSulfur, 1);
        private static readonly Recipe recipeCateriumOre = new Recipe("Caterium Ore", 1).AddOutput(materialCateriumOre, 1);
        private static readonly Recipe recipeLimestone = new Recipe("Limestone", 1).AddOutput(materialLimestone, 1);
        private static readonly Recipe recipeRawQuartz = new Recipe("Raw Quartz", 1).AddOutput(materialRawQuartz, 1);
        private static readonly Recipe recipeIronIngot = new Recipe("Iron Ingot", 2).AddInput(materialIronOre, 1).AddOutput(materialIronIngot, 1);
        private static readonly Recipe recipeIronAlloyIngot = new Recipe("Iron Alloy Ingot", 6).AddInput(materialIronOre, 2).AddInput(materialCopperOre, 2).AddOutput(materialIronIngot, 5);
        private static readonly Recipe recipePureIronIngot = new Recipe("Pure Iron Ingot", 12).AddInput(materialIronOre, 7).AddInput(materialWater, 4).AddOutput(materialIronIngot, 13);
        private static readonly Recipe recipeCopperIngot = new Recipe("Copper Ingot", 2).AddInput(materialCopperOre, 1).AddOutput(materialCopperIngot, 1);
        private static readonly Recipe recipeCopperAlloyIngot = new Recipe("Copper Alloy Ingot", 12).AddInput(materialCopperOre, 10).AddInput(materialIronOre, 5).AddOutput(materialCopperIngot, 20);
        private static readonly Recipe recipePureCopperIngot = new Recipe("Pure Copper Ingot", 24).AddInput(materialCopperOre, 6).AddInput(materialWater, 4).AddOutput(materialCopperIngot, 15);
        private static readonly Recipe recipeCateriumIngot = new Recipe("Caterium Ingot", 4).AddInput(materialCateriumOre, 3).AddOutput(materialCateriumIngot, 1);
        private static readonly Recipe recipePureCateriumIngot = new Recipe("Pure Caterium Ingot", 5).AddInput(materialCateriumOre, 2).AddInput(materialWater, 2).AddOutput(materialCateriumIngot, 1);
        private static readonly Recipe recipeIronRod = new Recipe("Iron Rod", 4).AddInput(materialIronIngot, 1).AddOutput(materialIronRod, 1);
        private static readonly Recipe recipeSteelRod = new Recipe("Steel Rod", 5).AddInput(materialSteelIngot, 1).AddOutput(materialIronRod, 4);
        private static readonly Recipe recipeIronPlate = new Recipe("Iron Plate", 6).AddInput(materialIronIngot, 3).AddOutput(materialIronPlate, 2);
        private static readonly Recipe recipeCoatedIronPlate = new Recipe("Coated Iron Plate", 12).AddInput(materialIronIngot, 10).AddInput(materialPlastic, 2).AddOutput(materialIronPlate, 15);
        private static readonly Recipe recipeSteelCoatedPlate = new Recipe("Steel Coated Plate", 24).AddInput(materialSteelIngot, 3).AddInput(materialPlastic, 2).AddOutput(materialIronPlate, 18);
        private static readonly Recipe recipeReinforcedIronPlate = new Recipe("Reinforced Iron Plate", 12).AddInput(materialIronPlate, 6).AddInput(materialScrew, 12).AddOutput(materialReinforcedIronPlate, 1);
        private static readonly Recipe recipeAdheredIronPlate = new Recipe("Adhered Iron Plate", 16).AddInput(materialIronPlate, 3).AddInput(materialRubber, 1).AddOutput(materialReinforcedIronPlate, 1);
        private static readonly Recipe recipeBoltedIronPlate = new Recipe("Bolted Iron Plate", 12).AddInput(materialIronPlate, 18).AddInput(materialScrew, 50).AddOutput(materialReinforcedIronPlate, 3);
        private static readonly Recipe recipeStitchedIronPlate = new Recipe("Stitched Iron Plate", 32).AddInput(materialIronPlate, 10).AddInput(materialWire, 20).AddOutput(materialReinforcedIronPlate, 3);
        private static readonly Recipe recipeWire = new Recipe("Wire", 4).AddInput(materialCopperIngot, 1).AddOutput(materialWire, 2);
        private static readonly Recipe recipeFusedWire = new Recipe("Fused Wire", 20).AddInput(materialCopperIngot, 4).AddInput(materialCateriumIngot, 1).AddOutput(materialWire, 30);
        private static readonly Recipe recipeIronWire = new Recipe("Iron Wire", 24).AddInput(materialIronIngot, 5).AddOutput(materialWire, 9);
        private static readonly Recipe recipeCateriumWire = new Recipe("Caterium Wire", 4).AddInput(materialCateriumIngot, 1).AddOutput(materialWire, 8);
        private static readonly Recipe recipeScrew = new Recipe("Screw", 6).AddInput(materialIronRod, 1).AddOutput(materialScrew, 4);
        private static readonly Recipe recipeCastScrew = new Recipe("Cast Screw", 24).AddInput(materialIronIngot, 5).AddOutput(materialScrew, 20);
        private static readonly Recipe recipeSteelScrew = new Recipe("Steel Screw", 12).AddInput(materialSteelBeam, 1).AddOutput(materialScrew, 52);
        private static readonly Recipe recipeSteelIngot = new Recipe("Steel Ingot", 4).AddInput(materialIronOre, 3).AddInput(materialCoal, 3).AddOutput(materialSteelIngot, 3);
        private static readonly Recipe recipeCokeSteelIngot = new Recipe("Coke Steel Ingot", 12).AddInput(materialIronOre, 15).AddInput(materialPetroleumCoke, 15).AddOutput(materialSteelIngot, 20);
        private static readonly Recipe recipeCompactedSteelIngot = new Recipe("Compacted Steel Ingot", 16).AddInput(materialIronOre, 6).AddInput(materialCompactedCoal, 3).AddOutput(materialSteelIngot, 10);
        private static readonly Recipe recipeSolidSteelIngot = new Recipe("Solid Steel Ingot", 3).AddInput(materialIronIngot, 2).AddInput(materialCoal, 2).AddOutput(materialSteelIngot, 3);
        private static readonly Recipe recipeSteelBeam = new Recipe("Steel Beam", 4).AddInput(materialSteelIngot, 4).AddOutput(materialSteelBeam, 1);
        private static readonly Recipe recipePetroleumCoke = new Recipe("Petroleum Coke", 6).AddInput(materialHeavyOilResidue, 4).AddOutput(materialPetroleumCoke, 12);
        private static readonly Recipe recipeHeavyOilResidue = new Recipe("Heavy Oil Residue", 6).AddInput(materialCrudeOil, 3).AddOutput(materialHeavyOilResidue, 4).AddOutput(materialPolymerResin, 2);
        private static readonly Recipe recipeCompactedCoal = new Recipe("Compacted Coal", 12).AddInput(materialCoal, 5).AddInput(materialSulfur, 5).AddOutput(materialCompactedCoal, 5);
        private static readonly Recipe recipeRubber = new Recipe("Rubber", 6).AddInput(materialCrudeOil, 3).AddOutput(materialRubber, 2).AddOutput(materialHeavyOilResidue, 2);
        private static readonly Recipe recipeResidualRubber = new Recipe("Residual Rubber", 6).AddInput(materialPolymerResin, 4).AddInput(materialWater, 4).AddOutput(materialRubber, 2);
        private static readonly Recipe recipeRecycledRubber = new Recipe("Recycled Rubber", 12).AddInput(materialPlastic, 6).AddInput(materialFuel, 6).AddOutput(materialRubber, 12);
        private static readonly Recipe recipeFuel = new Recipe("Fuel", 6).AddInput(materialCrudeOil, 6).AddOutput(materialFuel, 4).AddOutput(materialPolymerResin, 3);
        private static readonly Recipe recipePolymerResin = new Recipe("Polymer Resin", 6).AddInput(materialCrudeOil, 6).AddOutput(materialPolymerResin, 13).AddOutput(materialHeavyOilResidue, 2);
        private static readonly Recipe recipePlastic = new Recipe("Plastic", 6).AddInput(materialCrudeOil, 3).AddOutput(materialPlastic, 2).AddOutput(materialHeavyOilResidue, 1);
        private static readonly Recipe recipeResidualPlastic = new Recipe("Residual Plastic", 6).AddInput(materialPolymerResin, 6).AddInput(materialWater, 2).AddOutput(materialPlastic, 2);
        private static readonly Recipe recipeRecycledPlastic = new Recipe("Recycled Plastic", 12).AddInput(materialRubber, 6).AddInput(materialFuel, 6).AddOutput(materialPlastic, 12);
        private static readonly Recipe recipeCable = new Recipe("Cable", 2).AddInput(materialWire, 2).AddOutput(materialCable, 1);
        private static readonly Recipe recipeCoatedCable = new Recipe("Coated Cable", 8).AddInput(materialWire, 5).AddInput(materialHeavyOilResidue, 2).AddOutput(materialCable, 9);
        private static readonly Recipe recipeInsulatedCable = new Recipe("Insulated Cable", 12).AddInput(materialWire, 9).AddInput(materialRubber, 6).AddOutput(materialCable, 20);
        private static readonly Recipe recipeQuickwireCable = new Recipe("Quickwire Cable", 24).AddInput(materialQuickwire, 3).AddInput(materialRubber, 2).AddOutput(materialCable, 11);
        private static readonly Recipe recipeQuickwire = new Recipe("Quickwire", 5).AddInput(materialCateriumIngot, 3).AddOutput(materialQuickwire, 5);
        private static readonly Recipe recipeFusedQuickwire = new Recipe("Fused Quickwire", 8).AddInput(materialCateriumIngot, 1).AddInput(materialCopperIngot, 5).AddOutput(materialQuickwire, 12);
        private static readonly Recipe recipeCopperSheet = new Recipe("Copper Sheet", 6).AddInput(materialCopperIngot, 2).AddOutput(materialCopperSheet, 1);
        private static readonly Recipe recipeSteamedCopperSheet = new Recipe("Steamed Copper Sheet", 8).AddInput(materialCopperIngot, 3).AddInput(materialWater, 3).AddOutput(materialCopperSheet, 3);
        private static readonly Recipe recipeModularFrame = new Recipe("Modular Frame", 60).AddInput(materialReinforcedIronPlate, 3).AddInput(materialIronRod, 12).AddOutput(materialModularFrame, 2);
        private static readonly Recipe recipeBoltedFrame = new Recipe("Bolted Frame", 24).AddInput(materialReinforcedIronPlate, 3).AddInput(materialScrew, 56).AddOutput(materialModularFrame, 2);
        private static readonly Recipe recipeSteeledFrame = new Recipe("Steeled Frame", 60).AddInput(materialReinforcedIronPlate, 2).AddInput(materialSteelPipe, 10).AddOutput(materialModularFrame, 3);
        private static readonly Recipe recipeSteelPipe = new Recipe("Steel Pipe", 6).AddInput(materialSteelIngot, 3).AddOutput(materialSteelPipe, 2);
        private static readonly Recipe recipeRotor = new Recipe("Rotor", 15).AddInput(materialIronRod, 5).AddInput(materialScrew, 25).AddOutput(materialRotor, 1);
        private static readonly Recipe recipeCopperRotor = new Recipe("Copper Rotor", 16).AddInput(materialCopperSheet, 5).AddInput(materialScrew, 52).AddOutput(materialRotor, 3);
        private static readonly Recipe recipeSteelRotor = new Recipe("Steel Rotor", 12).AddInput(materialSteelPipe, 2).AddInput(materialWire, 6).AddOutput(materialRotor, 1);
        private static readonly Recipe recipeSmartPlating = new Recipe("Smart Plating", 30).AddInput(materialReinforcedIronPlate, 1).AddInput(materialRotor, 1).AddOutput(materialSmartPlating, 1);
        private static readonly Recipe recipePlasticSmartPlating = new Recipe("Plastic Smart Plating", 24).AddInput(materialReinforcedIronPlate, 1).AddInput(materialRotor, 1).AddInput(materialPlastic, 3).AddOutput(materialSmartPlating, 2);
        private static readonly Recipe recipeConcrete = new Recipe("Concrete", 4).AddInput(materialLimestone, 3).AddOutput(materialConcrete, 1);
        private static readonly Recipe recipeRubberConcrete = new Recipe("Rubber Concrete", 12).AddInput(materialLimestone, 10).AddInput(materialRubber, 2).AddOutput(materialConcrete, 9);
        private static readonly Recipe recipeWetConcrete = new Recipe("Wet Concrete", 3).AddInput(materialLimestone, 6).AddInput(materialWater, 5).AddOutput(materialConcrete, 4);
        private static readonly Recipe recipeFineConcrete = new Recipe("Fine Concrete", 24).AddInput(materialLimestone, 12).AddInput(materialSilica, 3).AddOutput(materialConcrete, 10);
        private static readonly Recipe recipeVersatileFramework = new Recipe("Versatile Framework", 24).AddInput(materialModularFrame, 1).AddInput(materialSteelBeam, 12).AddOutput(materialVersatileFramework, 2);
        private static readonly Recipe recipeFlexibleFramework = new Recipe("Flexible Framework", 16).AddInput(materialModularFrame, 1).AddInput(materialSteelBeam, 6).AddInput(materialRubber, 8).AddOutput(materialVersatileFramework, 2);
        private static readonly Recipe recipeAutomatedWiring = new Recipe("Automated Wiring", 24).AddInput(materialStator, 1).AddInput(materialCable, 20).AddOutput(materialAutomatedWiring, 1);
        private static readonly Recipe recipeAutomatedSpeedWiring = new Recipe("Automated Speed Wiring", 32).AddInput(materialStator, 2).AddInput(materialWire, 40).AddInput(materialHighspeedConnector, 1).AddOutput(materialAutomatedWiring, 4);
        private static readonly Recipe recipeEncasedIndustrialBeam = new Recipe("Encased Industrial Beam", 10).AddInput(materialSteelBeam, 4).AddInput(materialConcrete, 5).AddOutput(materialEncasedIndustrialBeam, 1);
        private static readonly Recipe recipeEncasedIndustrialPipe = new Recipe("Encased Industrial Pipe", 15).AddInput(materialSteelPipe, 7).AddInput(materialConcrete, 5).AddOutput(materialEncasedIndustrialBeam, 1);
        private static readonly Recipe recipeHeavyModularFrame = new Recipe("Heavy Modular Frame", 30).AddInput(materialModularFrame, 5).AddInput(materialSteelPipe, 15).AddInput(materialEncasedIndustrialBeam, 5).AddInput(materialScrew, 100).AddOutput(materialHeavyModularFrame, 1);
        private static readonly Recipe recipeHeavyFlexibleFrame = new Recipe("Heavy Flexible Frame", 16).AddInput(materialModularFrame, 5).AddInput(materialEncasedIndustrialBeam, 3).AddInput(materialRubber, 20).AddInput(materialScrew, 104).AddOutput(materialHeavyModularFrame, 1);
        private static readonly Recipe recipeHeavyEncasedFrame = new Recipe("Heavy Encased Frame", 64).AddInput(materialModularFrame, 8).AddInput(materialEncasedIndustrialBeam, 10).AddInput(materialSteelPipe, 36).AddInput(materialConcrete, 22).AddOutput(materialHeavyModularFrame, 3);
        private static readonly Recipe recipeStator = new Recipe("Stator", 12).AddInput(materialSteelPipe, 3).AddInput(materialWire, 8).AddOutput(materialStator, 1);
        private static readonly Recipe recipeQuickwireStator = new Recipe("Quickwire Stator", 15).AddInput(materialSteelPipe, 4).AddInput(materialQuickwire, 15).AddOutput(materialStator, 2);
        private static readonly Recipe recipeMotor = new Recipe("Motor", 12).AddInput(materialRotor, 2).AddInput(materialStator, 2).AddOutput(materialMotor, 1);
        private static readonly Recipe recipeRigourMotor = new Recipe("Rigour Motor", 48).AddInput(materialRotor, 3).AddInput(materialStator, 3).AddInput(materialCrystalOscillator, 1).AddOutput(materialMotor, 6);
        //private static readonly Recipe recipeElectricMotor = new Recipe("Electric Motor", 16).AddInput(materialRotor, 2).AddInput(materialElectromagneticControlRod, 1).AddOutput(materialMotor, 2);
        private static readonly Recipe recipeCircuitBoard = new Recipe("Circuit Board", 8).AddInput(materialCopperSheet, 2).AddInput(materialPlastic, 4).AddOutput(materialCircuitBoard, 1);
        private static readonly Recipe recipeElectrodeCircuitBoard = new Recipe("Electrode Circuit Board", 12).AddInput(materialRubber, 6).AddInput(materialPetroleumCoke, 9).AddOutput(materialCircuitBoard, 1);
        private static readonly Recipe recipeSiliconCircuitBoard = new Recipe("Silicon Circuit Board", 24).AddInput(materialCopperSheet, 11).AddInput(materialSilica, 11).AddOutput(materialCircuitBoard, 5);
        private static readonly Recipe recipeCateriumCircuitBoard = new Recipe("Caterium Circuit Board", 48).AddInput(materialPlastic, 10).AddInput(materialQuickwire, 30).AddOutput(materialCircuitBoard, 7);
        private static readonly Recipe recipeHighspeedConnector = new Recipe("High-Speed Connector", 16).AddInput(materialQuickwire, 56).AddInput(materialCable, 10).AddInput(materialCircuitBoard, 1).AddOutput(materialHighspeedConnector, 1);
        private static readonly Recipe recipeSiliconHighspeedConnector = new Recipe("Silicon High-Speed Connector", 16).AddInput(materialQuickwire, 60).AddInput(materialSilica, 25).AddInput(materialCircuitBoard, 2).AddOutput(materialHighspeedConnector, 1);
        private static readonly Recipe recipeCrystalOscillator = new Recipe("Crystal Oscillator", 120).AddInput(materialQuartzCrystal, 36).AddInput(materialCable, 28).AddInput(materialReinforcedIronPlate, 5).AddOutput(materialCrystalOscillator, 2);
        private static readonly Recipe recipeInsulatedCrystalOscillator = new Recipe("Insulated Crystal Oscillator", 32).AddInput(materialQuartzCrystal, 10).AddInput(materialRubber, 7).AddInput(materialAiLimiter, 1).AddOutput(materialCrystalOscillator, 1);
        private static readonly Recipe recipeQuartzCrystal = new Recipe("Quartz Crystal", 8).AddInput(materialRawQuartz, 5).AddOutput(materialQuartzCrystal, 3);
        private static readonly Recipe recipePureQuartzCrystal = new Recipe("Pure Quartz Crystal", 8).AddInput(materialRawQuartz, 9).AddInput(materialWater, 5).AddOutput(materialQuartzCrystal, 7);
        private static readonly Recipe recipeAiLimiter = new Recipe("AI Limiter", 12).AddInput(materialCopperSheet, 5).AddInput(materialQuickwire, 20).AddOutput(materialAiLimiter, 1);

        private static readonly List<Machine> knownMachines = new() {
            new Machine("Miner", 5)
                .AddRecipe(recipeIronOre)
                .AddRecipe(recipeCopperOre)
                .AddRecipe(recipeCoal)
                .AddRecipe(recipeSulfur)
                .AddRecipe(recipeCateriumOre)
                .AddRecipe(recipeLimestone)
                .AddRecipe(recipeRawQuartz),
            new Machine("Water Extractor", 20)
                .AddRecipe(recipeWater),
            new Machine("Oil Extractor", 40)
                .AddRecipe(recipeCrudeOil),
            new Machine("Smelter", 4)
                .AddRecipe(recipeIronIngot)
                .AddRecipe(recipeCopperIngot)
                .AddRecipe(recipeCateriumIngot),
            new Machine("Foundry", 16)
                .AddRecipe(recipeIronAlloyIngot)
                .AddRecipe(recipeCopperAlloyIngot)
                .AddRecipe(recipeSteelIngot)
                .AddRecipe(recipeCokeSteelIngot)
                .AddRecipe(recipeCompactedSteelIngot)
                .AddRecipe(recipeSolidSteelIngot),
            new Machine("Constructor", 4)
                .AddRecipe(recipeIronRod)
                .AddRecipe(recipeIronPlate)
                .AddRecipe(recipeWire)
                .AddRecipe(recipeIronWire)
                .AddRecipe(recipeCateriumWire)
                .AddRecipe(recipeScrew)
                .AddRecipe(recipeCastScrew)
                .AddRecipe(recipeSteelScrew)
                .AddRecipe(recipeSteelRod)
                .AddRecipe(recipeSteelBeam)
                .AddRecipe(recipeCable)
                .AddRecipe(recipeQuickwire)
                .AddRecipe(recipeCopperSheet)
                .AddRecipe(recipeSteelPipe)
                .AddRecipe(recipeConcrete)
                .AddRecipe(recipeQuartzCrystal),
            new Machine("Assembler", 15)
                .AddRecipe(recipeFusedWire)
                .AddRecipe(recipeReinforcedIronPlate)
                .AddRecipe(recipeAdheredIronPlate)
                .AddRecipe(recipeBoltedIronPlate)
                .AddRecipe(recipeStitchedIronPlate)
                .AddRecipe(recipeCompactedCoal)
                .AddRecipe(recipeInsulatedCable)
                .AddRecipe(recipeQuickwireCable)
                .AddRecipe(recipeFusedQuickwire)
                .AddRecipe(recipeBoltedFrame)
                .AddRecipe(recipeModularFrame)
                .AddRecipe(recipeSteeledFrame)
                .AddRecipe(recipeRotor)
                .AddRecipe(recipeCopperRotor)
                .AddRecipe(recipeSteelRotor)
                .AddRecipe(recipeSmartPlating)
                .AddRecipe(recipeRubberConcrete)
                .AddRecipe(recipeFineConcrete)
                .AddRecipe(recipeCoatedIronPlate)
                .AddRecipe(recipeSteelCoatedPlate)
                .AddRecipe(recipeVersatileFramework)
                .AddRecipe(recipeAiLimiter)
                .AddRecipe(recipeMotor)
                .AddRecipe(recipeStator)
                .AddRecipe(recipeQuickwireStator)
                .AddRecipe(recipeEncasedIndustrialBeam)
                .AddRecipe(recipeEncasedIndustrialPipe)
                .AddRecipe(recipeAutomatedWiring)
                .AddRecipe(recipeCircuitBoard)
                .AddRecipe(recipeCateriumCircuitBoard)
                .AddRecipe(recipeElectrodeCircuitBoard)
                .AddRecipe(recipeSiliconCircuitBoard),
            new Machine("Manufacturer", 55)
                .AddRecipe(recipePlasticSmartPlating)
                .AddRecipe(recipeFlexibleFramework)
                //.AddRecipe(recipeCrystalOscillator)
                .AddRecipe(recipeInsulatedCrystalOscillator)
                .AddRecipe(recipeRigourMotor)
                .AddRecipe(recipeHeavyModularFrame)
                .AddRecipe(recipeHeavyFlexibleFrame)
                .AddRecipe(recipeHeavyEncasedFrame)
                .AddRecipe(recipeHighspeedConnector)
                .AddRecipe(recipeSiliconHighspeedConnector)
                .AddRecipe(recipeAutomatedSpeedWiring),
            new Machine("Refinery", 30)
                .AddRecipe(recipePureIronIngot)
                .AddRecipe(recipePureCopperIngot)
                .AddRecipe(recipePureCateriumIngot)
                .AddRecipe(recipePetroleumCoke)
                .AddRecipe(recipeHeavyOilResidue)
                .AddRecipe(recipeRubber)
                .AddRecipe(recipeResidualRubber)
                .AddRecipe(recipePlastic)
                .AddRecipe(recipeResidualPlastic)
                .AddRecipe(recipeFuel)
                .AddRecipe(recipePolymerResin)
                .AddRecipe(recipeCoatedCable)
                .AddRecipe(recipeSteamedCopperSheet)
                .AddRecipe(recipeWetConcrete)
                .AddRecipe(recipePureQuartzCrystal),
            new Machine("Packager", 10),
            new Machine("Blender", 75),
            new Machine("Particle Accelerator", 1500),
        };

        private static readonly List<Recipe> knownRecipes = new(knownMachines.SelectMany(x => x.Recipes).ToList());

        private static readonly List<Material> knownMaterials = new(knownRecipes.SelectMany(x => x.Outputs).Select(y => y.Item1).Distinct().ToList());

        static void Main(string[] args) {
            string listingSeperator = Environment.NewLine + "  * ";
            foreach (string arg in args) {
                switch (arg) {
                    case "-mats":
                        Console.WriteLine("Known materials: " + listingSeperator + string.Join(", " + listingSeperator, knownMaterials) + Environment.NewLine);
                        break;
                    case "-reci":
                        Console.WriteLine("Known recipes: " + listingSeperator + string.Join(", " + listingSeperator, knownRecipes) + Environment.NewLine);
                        break;
                    case "-mach":
                        Console.WriteLine("Known machines: " + listingSeperator + string.Join(", " + listingSeperator, knownMachines) + Environment.NewLine);
                        break;
                    default:
                        Console.WriteLine($"Ignoring unknown argument '{arg}'.");
                        break;
                }
            }

            Material targetMaterial = materialMotor;
            Console.WriteLine($"Trying to find recipes for material '{targetMaterial}'...");

            List<ProductionTree> options = ProductionTree.GetAllProductionOptions(targetMaterial, 60, knownMachines);
            foreach (var o in options) {
                //Console.WriteLine(o);
                //Console.WriteLine($"Power: {o.CalculatePowerUsage():0.00}MW");
                //Console.WriteLine($"Machines: {string.Join(", ", o.CalculateMachinesNeeded().Select(x => x.Value + "x " + x.Key.Name))}");
                //Console.WriteLine($"Ressources: {string.Join(", ", o.CalculateBasicRessourcesNeeded().Select(x => x.Value.ToString("0.00") + "x " + x.Key.Name))}");
                //Console.WriteLine();
            }
            Console.WriteLine($"Found {options.Count} unique options to produce '{targetMaterial}'.");
            Console.WriteLine("Done.");
        }
    }
}
