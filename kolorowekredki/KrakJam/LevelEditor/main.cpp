#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main(int argc, char ** argv)
{
	string filename1, filename2;
	int x, y;
	char c;
	ifstream fileIn;
	ofstream fileOut;
	if (argc == 2)
	{
		filename1 = argv[1];
	}
	else
	{
		getline(cin, filename1);
	}
	fileIn.open(filename1.c_str());
	fileIn >> x >> y;
	for (int i = 0 ; i < filename1.length() - 3 ; ++i)
	{
		filename2 += filename1[i];
	}
	filename2 += "xml";
	fileOut.open(filename2.c_str());
	fileOut << "<?xml version=\"1.0\"?>\n"
			<< "<Level xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\n"
			<< "  <MapTiles>\n";
	for (int i = 0 ; i < y ; ++i)
	{
		for (int j = 0 ; j < x ; ++j)
		{
			fileIn >> c;
			switch (c)
			{
				case '0':
					break;
				case '1':
					fileOut << "    <MapTile>\n"
							<< "      <Position>\n"
							<< "        <X>" << 64 + j * 64 << "</X>\n"
							<< "        <Y>" << 64 + i * 64 << "</Y>\n"
							<< "      </Position>\n"
							<< "      <TileSize>\n"
							<< "        <X>64</X>\n"
							<< "        <Y>64</Y>\n"
							<< "      </TileSize>\n"
							<< "      <TextureFile>sampleTile</TextureFile>\n"
							<< "    </MapTile>\n";
					break;
			}
		}
	}
	fileOut << "  </MapTiles>\n"
			<< "  <MapObjects>\n";
	for (int j = 0 ; j < x ; ++j)
	{
		fileIn >> c;
		switch (c)
		{
			case 'o':
				break;
			case 'x':
				fileOut << "    <BaseGameObject xsi:type=\"Rope\">\n"
						<< "      <Position>\n"
						<< "        <X>" << 64 + j * 64 << "</X>\n"
						<< "        <Y>10</Y>\n"
						<< "      </Position>\n"
						<< "      <WorldPosition>\n"
						<< "        <X>" << 64 + j * 64 << "</X>\n"
						<< "        <Y>10</Y>\n"
						<< "      </WorldPosition>\n"
						<< "      <CameraDirection>\n"
						<< "        <X>0</X>\n"
						<< "        <Y>0</Y>\n"
						<< "      </CameraDirection>\n"
						<< "      <Texture>rope.bmp</Texture>\n"
						<< "      <Type>Rope</Type>\n"
						<< "    </BaseGameObject>\n";
				break;
		}
	}
	fileOut << "  </MapObjects>\n"
			<< "  <MapBackgroundLayer1>background1</MapBackgroundLayer1>\n"
			<< "  <MapBackgroundLayer2>background2</MapBackgroundLayer2>\n"
			<< "  <PlayerCharacterDescription>MonkeyPlayer.xml</PlayerCharacterDescription>\n"
			<< "</Level>\n";
	return 0;
}
