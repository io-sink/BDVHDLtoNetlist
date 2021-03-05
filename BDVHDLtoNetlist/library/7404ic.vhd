library IEEE;
use IEEE.std_logic_1164.all; 

entity 7404ic is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of 7404ic is "74xx";
	attribute component_name of 7404ic is "74HC04";
	attribute footprint_name of 7404ic is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 7;
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 14;

	1A : in std_logic;
	attribute pin_assign of 1A is 1;
	1Y : out std_logic;
	attribute pin_assign of 1Y is 2;

	2A : in std_logic;
	attribute pin_assign of 2A is 3;
	2Y : out std_logic;
	attribute pin_assign of 2Y is 4;

	3A : in std_logic;
	attribute pin_assign of 3A is 5;
	3Y : out std_logic;
	attribute pin_assign of 3Y is 6;

	4A : in std_logic;
	attribute pin_assign of 4A is 9;
	4Y : out std_logic;
	attribute pin_assign of 4Y is 8;

	5A : in std_logic;
	attribute pin_assign of 5A is 11;
	5Y : out std_logic;
	attribute pin_assign of 5Y is 10;

	6A : in std_logic;
	attribute pin_assign of 6A is 13;
	6Y : out std_logic;
	attribute pin_assign of 6Y is 12
	);
	end 7404ic;

architecture logic of 7404ic is 
begin 

	1Y <= not 1A;
	2Y <= not 2A;
	3Y <= not 3A;
	4Y <= not 4A;
	5Y <= not 5A;
	6Y <= not 6A;

end logic;