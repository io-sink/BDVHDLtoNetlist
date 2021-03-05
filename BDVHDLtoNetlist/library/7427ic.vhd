library IEEE;
use IEEE.std_logic_1164.all; 

entity 7427ic is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of 7427ic is "74xx";
	attribute component_name of 7427ic is "74HC27";
	attribute footprint_name of 7427ic is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

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
	attribute pin_assign of 1C is 13;
	1Y : out std_logic;
	attribute pin_assign of 1Y is 12;

	2A : in std_logic;
	attribute pin_assign of 2A is 3;
	2B : in std_logic;
	attribute pin_assign of 2B is 4;
	2C : in std_logic;
	attribute pin_assign of 2C is 5;
	2Y : out std_logic;
	attribute pin_assign of 2Y is 6;
	
	3A : in std_logic;
	attribute pin_assign of 3A is 9;
	3B : in std_logic;
	attribute pin_assign of 3B is 10;
	3C : in std_logic;
	attribute pin_assign of 3C is 11;
	3Y : out std_logic;
	attribute pin_assign of 3Y is 8
	
	);
	end 7427ic;

architecture logic of 7427ic is 
begin 

	1Y <= not(1A or 1B or 1C);
	2Y <= not(2A or 2B or 2C);
	3Y <= not(3A or 3B or 3C);

end logic;