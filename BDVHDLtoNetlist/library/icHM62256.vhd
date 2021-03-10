library IEEE;
use IEEE.std_logic_1164.all; 

entity icHM62256 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of icHM62256 is "Memory_RAM";
	attribute component_name of icHM62256 is "HM62256BLP";
	attribute footprint_name of icHM62256 is "Package_DIP:DIP-28_W15.24mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 14;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 28;
	attribute pin_type of VCC is "power_in";

	CE : IN STD_LOGIC;
  attribute pin_assign of CE is 20;
  attribute pin_type of CE is "input";
	OE : IN STD_LOGIC;
  attribute pin_assign of OE is 22;
  attribute pin_type of OE is "input";
	WE : IN STD_LOGIC;
  attribute pin_assign of WE is 27;
  attribute pin_type of WE is "input";

	A0 : IN STD_LOGIC;
  attribute pin_assign of A0 is 10;
  attribute pin_type of A0 is "input";
	A1 : IN STD_LOGIC;
  attribute pin_assign of A1 is 9;
  attribute pin_type of A1 is "input";
	A2 : IN STD_LOGIC;
  attribute pin_assign of A2 is 8;
  attribute pin_type of A2 is "input";
	A3 : IN STD_LOGIC;
  attribute pin_assign of A3 is 7;
  attribute pin_type of A3 is "input";
	A4 : IN STD_LOGIC;
  attribute pin_assign of A4 is 6;
  attribute pin_type of A4 is "input";
	A5 : IN STD_LOGIC;
  attribute pin_assign of A5 is 5;
  attribute pin_type of A5 is "input";
	A6 : IN STD_LOGIC;
  attribute pin_assign of A6 is 4;
  attribute pin_type of A6 is "input";
	A7 : IN STD_LOGIC;
  attribute pin_assign of A7 is 3;
  attribute pin_type of A7 is "input";
	A8 : IN STD_LOGIC;
  attribute pin_assign of A8 is 25;
  attribute pin_type of A8 is "input";
	A9 : IN STD_LOGIC;
  attribute pin_assign of A9 is 24;
  attribute pin_type of A9 is "input";
	A10 : IN STD_LOGIC;
  attribute pin_assign of A10 is 21;
  attribute pin_type of A10 is "input";
	A11 : IN STD_LOGIC;
  attribute pin_assign of A11 is 23;
  attribute pin_type of A11 is "input";
	A12 : IN STD_LOGIC;
  attribute pin_assign of A12 is 2;
  attribute pin_type of A12 is "input";
	A13 : IN STD_LOGIC;
  attribute pin_assign of A13 is 26;
  attribute pin_type of A13 is "input";
	A14 : IN STD_LOGIC;
  attribute pin_assign of A14 is 1;
  attribute pin_type of A14 is "input";

	IO0 : INOUT STD_LOGIC;
  attribute pin_assign of IO0 is 11;
  attribute pin_type of IO0 is "3state";
	IO1 : INOUT STD_LOGIC;
  attribute pin_assign of IO1 is 12;
  attribute pin_type of IO1 is "3state";
	IO2 : INOUT STD_LOGIC;
  attribute pin_assign of IO2 is 13;
  attribute pin_type of IO2 is "3state";
	IO3 : INOUT STD_LOGIC;
  attribute pin_assign of IO3 is 15;
  attribute pin_type of IO3 is "3state";
	IO4 : INOUT STD_LOGIC;
  attribute pin_assign of IO4 is 16;
  attribute pin_type of IO4 is "3state";
	IO5 : INOUT STD_LOGIC;
  attribute pin_assign of IO5 is 17;
  attribute pin_type of IO5 is "3state";
	IO6 : INOUT STD_LOGIC;
  attribute pin_assign of IO6 is 18;
  attribute pin_type of IO6 is "3state";
	IO7 : INOUT STD_LOGIC;
  attribute pin_assign of IO7 is 19;
  attribute pin_type of IO7 is "3state"
	);
	end icHM62256;

architecture logic of icHM62256 is 
	component compHM62256
		port (
			CE : IN STD_LOGIC;
			OE : IN STD_LOGIC;
			WE : IN STD_LOGIC;
			A0 : IN STD_LOGIC;
			A1 : IN STD_LOGIC;
			A2 : IN STD_LOGIC;
			A3 : IN STD_LOGIC;
			A4 : IN STD_LOGIC;
			A5 : IN STD_LOGIC;
			A6 : IN STD_LOGIC;
			A7 : IN STD_LOGIC;
			A8 : IN STD_LOGIC;
			A9 : IN STD_LOGIC;
			A10 : IN STD_LOGIC;
			A11 : IN STD_LOGIC;
			A12 : IN STD_LOGIC;
			A13 : IN STD_LOGIC;
			A14 : IN STD_LOGIC;
			IO0 : INOUT STD_LOGIC;
			IO1 : INOUT STD_LOGIC;
			IO2 : INOUT STD_LOGIC;
			IO3 : INOUT STD_LOGIC;
			IO4 : INOUT STD_LOGIC;
			IO5 : INOUT STD_LOGIC;
			IO6 : INOUT STD_LOGIC;
			IO7 : INOUT STD_LOGIC
			);
	end component;
begin 

	inst : compHM62256
		port map (
			CE => CE, 
			OE => OE, 
			WE => WE, 
			A0 => A0, 
			A1 => A1, 
			A2 => A2, 
			A3 => A3, 
			A4 => A4, 
			A5 => A5, 
			A6 => A6, 
			A7 => A7, 
			A8 => A8, 
			A9 => A9, 
			A0 => A0, 
			A10 => A10, 
			A11 => A11, 
			A12 => A12, 
			A13 => A13, 
			A14 => A14, 
			IO0 => IO0, 
			IO1 => IO1, 
			IO2 => IO2, 
			IO3 => IO3, 
			IO4 => IO4, 
			IO5 => IO5, 
			IO6 => IO6, 
			IO7 => IO7
		);

end logic;