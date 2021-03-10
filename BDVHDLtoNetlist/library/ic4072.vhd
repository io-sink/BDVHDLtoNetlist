library IEEE;
use IEEE.std_logic_1164.all; 

entity ic4072 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic4072 is "4xxx";
	attribute component_name of ic4072 is "4072";
	attribute footprint_name of ic4072 is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 7;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 14;
	attribute pin_type of VCC is "power_in";

	NC1 : in std_logic;
	attribute const_assign of NC1 is "open";
	attribute pin_assign of NC1 is 6;
	attribute pin_type of NC1 is "input";
	NC2 : in std_logic;
	attribute const_assign of NC2 is "open";
	attribute pin_assign of NC2 is 8;
	attribute pin_type of NC2 is "input";

	A1 : in std_logic;
	attribute pin_assign of A1 is 2;
	attribute pin_type of A1 is "input";
	B1 : in std_logic;
	attribute pin_assign of B1 is 3;
	attribute pin_type of B1 is "input";
	C1 : in std_logic;
	attribute pin_assign of C1 is 4;
	attribute pin_type of C1 is "input";
	D1 : in std_logic;
	attribute pin_assign of D1 is 5;
	attribute pin_type of D1 is "input";
	Y1 : out std_logic;
	attribute pin_assign of Y1 is 1;
	attribute pin_type of Y1 is "output";

	A2 : in std_logic;
	attribute pin_assign of A2 is 9;
	attribute pin_type of A2 is "input";
	B2 : in std_logic;
	attribute pin_assign of B2 is 10;
	attribute pin_type of B2 is "input";
	C2 : in std_logic;
	attribute pin_assign of C2 is 12;
	attribute pin_type of C2 is "input";
	D2 : in std_logic;
	attribute pin_assign of D2 is 13;
	attribute pin_type of D2 is "input";
	Y2 : out std_logic;
	attribute pin_assign of Y2 is 13;
	attribute pin_type of Y2 is "output"
	);
	end ic4072;

architecture logic of ic4072 is 
begin 

	Y1 <= A1 or B1 or C1 or D1;
	Y2 <= A2 or B2 or C2 or D2;

end logic;