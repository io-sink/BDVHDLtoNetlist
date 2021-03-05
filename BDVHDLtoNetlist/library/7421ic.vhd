library IEEE;
use IEEE.std_logic_1164.all; 

entity 7421ic is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of 7421ic is "74xx";
	attribute component_name of 7421ic is "74HC21";
	attribute footprint_name of 7421ic is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 7;
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 14;

	1A : in std_logic;
	attribute pin_assign of 1A is 1;
	1B : in std_logic;
	attribute pin_assign of 1B is 2;
	1C : in std_logic;
	attribute pin_assign of 1C is 4;
	1D : in std_logic;
	attribute pin_assign of 1D is 5;
	1Y : out std_logic;
	attribute pin_assign of 1Y is 6;

	2A : in std_logic;
	attribute pin_assign of 2A is 9;
	2B : in std_logic;
	attribute pin_assign of 2B is 10;
	2C : in std_logic;
	attribute pin_assign of 2C is 12;
	2D : in std_logic;
	attribute pin_assign of 2D is 13;
	2Y : out std_logic;
	attribute pin_assign of 2Y is 8
	);
	end 7421ic;

architecture logic of 7421ic is 
begin 

	1Y <= 1A and 1B and 1C and 1D;
	2Y <= 2A and 2B and 2C and 2D;

end logic;